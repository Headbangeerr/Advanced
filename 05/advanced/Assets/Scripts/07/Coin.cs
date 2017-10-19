using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private Transform m_tranform;

    private GUIText m_GUIText;
	// Use this for initialization
	void Start () {
        m_tranform = gameObject.GetComponent<Transform>();
        m_GUIText = GameObject.Find("Score").GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
        m_tranform.Rotate(Vector3.forward, 10f);
	}
    public void addScore() {
        int s =int.Parse( m_GUIText.text);
        m_GUIText.text = (s+1).ToString();
    }
}
