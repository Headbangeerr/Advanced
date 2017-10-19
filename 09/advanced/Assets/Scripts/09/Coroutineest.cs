using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutineest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log("任务1");
        Debug.Log("任务2");
        //Debug.Log("任务3");
        StartCoroutine("Task3");
        Debug.Log("任务4");

    }
    IEnumerator Task3()
    {
      
        yield return new WaitForSeconds(1);
        Debug.Log("任务3");
    }

}
