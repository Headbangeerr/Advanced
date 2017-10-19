using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
    private Transform m_Transform;
    private Transform m_Pointer;
    private LineRenderer m_LineRenderer;
    private AudioSource m_AudioSource;
    //控制手臂能否移动的标志位
    private bool canMove = true;

    private GameManager m_GameManager;

    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        //m_pointer = GameObject.Find("Pointer").GetComponent<Transform>(); 使用这种查找方式的话，如果在场景中用同名物体就不能正常获取
        m_Pointer = m_Transform.Find("Pointer");//使用本物体的Transform组件的FindChild方法就可以查找该物体的子物体
        m_LineRenderer = m_Pointer.GetComponent<LineRenderer>();
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
    }
    /// <summary>
    /// 修改状态标识位
    /// </summary>
    /// <param name="state">目标状态</param>
    public void ChangeCanMove(bool state)
    {
        canMove = state;
    }
    void Update()
    {
        if (canMove)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //控制手臂“看向”指定碰撞点
                m_Transform.LookAt(hit.point);
                //绘制线        
                Debug.DrawLine(m_Pointer.position, hit.point, Color.red);
                //LineRenderer的位置坐标有两个，第一个为起点坐标，第二个为终点坐标
                //第一个int参数指定都是位置坐标的索引，0代表第一个坐标，1代表第二个
                m_LineRenderer.SetPosition(0, m_Pointer.position);
                m_LineRenderer.SetPosition(1, hit.point);

                //飞盘射击
                if (hit.collider.tag == "Frisbee" && Input.GetMouseButtonDown(0))
                {
                    //播放设计音效
                    m_AudioSource.Play();
                    //由于物理射线碰撞的物体只是飞盘碎片中的一个子物体，所以通过碰撞体获取到该物体的父物体
                    Transform parent = hit.collider.gameObject.GetComponent<Transform>().parent;
                    //通过父物体获取到所有子物体的某个组件
                    Transform[] frisbees = parent.GetComponentsInChildren<Transform>();
                    for (int i = 0; i < frisbees.Length; i++)
                    {
                        //给每一个碎片添加刚体组件，实现碎片破碎落地的效果
                        frisbees[i].gameObject.AddComponent<Rigidbody>();
                    }
                    m_GameManager.AddScore();
                    Destroy(parent.gameObject, 2.0f);
                }
            }
        }
    
    }
}
