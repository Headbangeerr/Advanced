using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTest : MonoBehaviour {

    public GameObject prefab_cube;

    private GameObject m_cube;
	void Start () {
		
	}
	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_cube = Instantiate(prefab_cube, Vector3.zero, Quaternion.identity);
        }

	}
}
