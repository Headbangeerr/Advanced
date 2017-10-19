using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        GameObject.Destroy(gameObject, Random.Range(5.0f, 10.0f));
        //写在start中可以实现，当该脚本所挂载的游戏物体一经实例化就开始计时
	}
	//用不到的代码要删掉，节约系统资源
}
