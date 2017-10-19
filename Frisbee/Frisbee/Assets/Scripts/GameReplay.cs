using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplay : MonoBehaviour {

    private GameManager m_GameManager;
	void Start () {
        m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
	}
    private void OnMouseDown()
    {
        m_GameManager.ChangerGameState(GameManager.GameState.START);
        m_GameManager.ResetGame();
    }	
	
}
