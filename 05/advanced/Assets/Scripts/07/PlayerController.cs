using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody m_Rigidbody;
    private Transform m_Transform;

    public GameObject prefab_coin;
	// Use this for initialization
	void Start () {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_Transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.forward * 0.2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.back * 0.2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.left * 0.2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Rigidbody.MovePosition(m_Transform.position + Vector3.right * 0.2f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Vector3 position = m_Transform.position;
            Destroy(collision.gameObject);
            Instantiate(prefab_coin,position + Vector3.forward * 1.0f,Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Coin")
        {
            //通过消息机制来调用脚本中的某个方法
            //coll.gameObject.SendMessage("addScore");
            coll.gameObject.GetComponent<Coin>().addScore();
            //上述代码的含义是通过gameObject属性获取名为“Coin”的脚本组件，然后再调用其中的具体方法，
            Destroy(coll.gameObject);
        }
    }
}
