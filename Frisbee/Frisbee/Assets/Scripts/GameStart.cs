using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    private GameManager m_GameManager;
	// Use this for initialization
	void Start () {
        m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
	}
    private void OnMouseDown()
    {
        m_GameManager.ChangerGameState(GameManager.GameState.GAME);
    }
}
