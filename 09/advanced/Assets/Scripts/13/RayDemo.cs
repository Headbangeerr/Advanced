using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDemo : MonoBehaviour {
    int x = 10;
    int y = 5;
    private Ray ray;
    private RaycastHit rayhit;
    public GameObject prefabBrick;
    public GameObject prefabBullet;
    private Transform m_transform;
	void Start () {
        createWall();
        m_transform = gameObject.GetComponent<Transform>();
	}
    void Update()
    {
        shootBullet();
    }
    /// <summary>
    /// 使用双重for循环创建一堵墙
    /// </summary>
    void createWall() {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                GameObject go = GameObject.Instantiate(prefabBrick, new Vector3(i - 5, j, 0), Quaternion.identity);
                float r = Random.Range(0.0f, 1.0f);
                float g = Random.Range(0.0f, 1.0f);
                float b = Random.Range(0.0f, 1.0f);
                go.GetComponent<MeshRenderer>().material.color=new Color(r,g,b);
            }
        }
    }
    void shootBullet() {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rayhit))
            {
                //实例化子弹
                GameObject go = GameObject.Instantiate(prefabBullet, m_transform.position, Quaternion.identity);
                //通过将射线碰撞点的位置减去摄像机所在位置就可以得到一个发射方向
                //这里涉及到一个Vector3类型的计算：终点B坐标减去起点A坐标就可以得到一个起点A到中点B的一个方向（简单的几何学！）
                Vector3 dir = rayhit.point - m_transform.position;
                //三个参数分别为一个Vector3类型的起点，第二个参数为射线方向，第三个参数为射线颜色
                Debug.DrawRay(m_transform.position, dir, Color.red);
                //发射子弹
                go.GetComponent<Rigidbody>().AddForce(dir * 120);
            }
        }
    }
	
}
