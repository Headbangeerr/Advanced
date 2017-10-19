using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture : MonoBehaviour {

    private GUITexture m_GUITexture;
	// Use this for initialization
	void Start () {
        m_GUITexture = gameObject.GetComponent<GUITexture>();
	}

    void OnMouseEnter() {
        m_GUITexture.color = Color.red;
    }
    void OnMouseExit()
    {
        m_GUITexture.color = Color.blue;

    }
    void OnMouseDown()
    {
        m_GUITexture.color = Color.yellow;
    }
    void OnMouseUp()
    {
        m_GUITexture.color = Color.gray;

    }


	// Update is called once per frame
	void Update () {
		
	}
}
