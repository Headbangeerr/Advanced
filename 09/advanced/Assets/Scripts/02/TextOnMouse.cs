using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnMouse : MonoBehaviour {

    private GUIText m_GUIText;
	// Use this for initialization
	void Start () {
        m_GUIText = gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseEnter() {
        m_GUIText.color = Color.red;
    }
    void OnMouseExit() {
        m_GUIText.color = Color.blue;
    }
    void OnMouseDown() {
        m_GUIText.color = Color.yellow;
    }
   
}
