using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	
	void Start () {
        //第二个参数的含义是多少秒后执行销毁
        GameObject.Destroy(gameObject,2);
	}
	
	
}
