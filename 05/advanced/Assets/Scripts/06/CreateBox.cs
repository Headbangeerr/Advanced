using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBox : MonoBehaviour {

    public GameObject goPrefab;

	// Use this for initialization

	void Start () {
        //Invoke("createBox", 2.0f);
        InvokeRepeating("createBox", 2.0f,2.0f );
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            createBox();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CancelInvoke();
        }
    }
    void createBox()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 postion = new Vector3(Random.Range(-9.0f, 9.0f), 1, Random.Range(-10.0f, 10.0f));
            GameObject.Instantiate(goPrefab, postion, Quaternion.identity);
        }
       
    }
}
