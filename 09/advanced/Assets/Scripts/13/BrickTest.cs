using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTest : MonoBehaviour {

    private Transform m_transform;
	void Start () {
        m_transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_transform.position.y < -5 )
        {
            Destroy(gameObject);
        }
	}
}
