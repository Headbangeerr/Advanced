using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest: MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraSendRay();
	}
    /// <summary>
    /// 点击鼠标发射物理射线，将与射线发生碰撞的物体销毁
    /// </summary>
    void CameraSendRay() {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {//通过物理类判断物理射线是否与其他物体发生碰撞 
                //通过RaycastHit获取射线碰撞到的Collider对象
                GameObject.Destroy(hit.collider.gameObject);
            }
        }
    }
}

