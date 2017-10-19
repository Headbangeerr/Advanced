using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsClass : MonoBehaviour {

    private float num=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("宽度："+Screen.width);
            Debug.Log("高度"+Screen.height);
        }
        //插值运算，用于平滑过渡
        num = Mathf.Lerp(num, 10, Time.deltaTime);
        Debug.Log(num);
	}
}
