using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FribeesManager : MonoBehaviour {
    public GameObject perfab_Frisbee;
    private Transform m_Transform;
    private bool canCreate;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
    }
    /// <summary>
    /// 开始生成飞盘
    /// </summary>
    public void StartCreateFrisbee() {
        InvokeRepeating("CreateFrisbee", 2.0f, 2.0f);
    }
    /// <summary>
    /// 停止生成飞盘
    /// </summary>
    public void StopCreateFrisbee() {
        CancelInvoke("CreateFrisbee");
    }


    /// <summary>
    /// 创建飞盘
    /// </summary>
    void CreateFrisbee()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-5.0f, 6.0f), Random.Range(0.5f, 4.0f), Random.Range(7.0f, 14.0f));
            //实例化生成一个新的飞盘
            GameObject go = GameObject.Instantiate(perfab_Frisbee, pos, Quaternion.identity);
            //使用setParent方法可以给某个物体赋予一个父物体
            go.GetComponent<Transform>().SetParent(m_Transform);
        }
       
    }
}
