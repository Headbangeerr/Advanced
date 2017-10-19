using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// 游戏状态枚举
    /// </summary>
    public enum GameState
    {
        START,
        GAME,
        END
    }
    private GameObject m_StartUI;
    private GameObject m_GameUI;
    private GameObject m_EndUI;
    private Transform m_FrisbeeParent_Transform;

    private GUIText m_GUIText_Score;
    private GUIText m_GUIText_Time;
    private GUIText m_GUIText_TotalScore;
    //背景音乐
    private AudioSource m_bg;
    //当前的游戏状态
    private GameState gameState;
    //开启倒计时标志位
    private bool startTime = false;

    private Weapon m_Weapon;
    private FribeesManager m_FribeesManager;
    //用于存储分数
    private int score;
    //游戏时间
    private float time = 10;

	void Start () {
        m_StartUI = GameObject.Find("StartUI");
        m_GameUI = GameObject.Find("GameUI");
        m_EndUI = GameObject.Find("EndUI");
        m_bg = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        m_Weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        m_FribeesManager = GameObject.Find("FrisbeeParent").GetComponent<FribeesManager>();
        m_GUIText_Score = GameObject.Find("GameScore").GetComponent<GUIText>();
        m_GUIText_Time = GameObject.Find("GameTime").GetComponent<GUIText>();
        m_GUIText_TotalScore = GameObject.Find("GameTotalScore").GetComponent<GUIText>();
        m_FrisbeeParent_Transform = GameObject.Find("FrisbeeParent").GetComponent<Transform>();
        ChangerGameState(GameState.START);        
    }
    private void Update()
    {
        if (startTime)
        {
            //减去每帧的渲染间隔，实现倒计时效果
            time -= Time.deltaTime;
            m_GUIText_Time.text = "时间：" + time + "秒";
            if (time < 0)
            {
                ChangerGameState(GameState.END);
                m_GUIText_TotalScore.text = "总分数：" + score + "分";
            }
           
        }
    }
    void StartTime() {
        startTime = true;
    }
    public void ResetGame()
    {
        time = 10;
        m_GUIText_Score.text = "分数：0分";
        score = 0;
        startTime = false;
        //通过父物体销毁所有飞盘子物体
        foreach(Transform child in m_FrisbeeParent_Transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void AddScore()
    {
        score++;
        m_GUIText_Score.text = "分数：" + score+"分";
    }
    /// <summary>
    /// 用于切换游戏状态
    /// </summary>
    /// <param name="state">要切换到的目标状态</param>
    public void ChangerGameState(GameState state)
    {
        gameState = state;
        if (gameState == GameState.START)   //开始状态
        {
            m_StartUI.SetActive(true);
            m_GameUI.SetActive(false);
            m_EndUI.SetActive(false);
            //关闭背景音乐
            m_bg.Stop();
            m_Weapon.ChangeCanMove(false);
        }
        else if (gameState == GameState.GAME)  //进行状态
        {
            m_StartUI.SetActive(false);
            m_GameUI.SetActive(true);
            m_EndUI.SetActive(false);
            m_bg.Play();
            m_Weapon.ChangeCanMove(true);
            m_FribeesManager.StartCreateFrisbee();
            //开始倒计时
            StartTime();
        }
        else if (gameState == GameState.END)    //结束状态
        {
            m_StartUI.SetActive(false);
            m_GameUI.SetActive(false);
            m_EndUI.SetActive(true);
            m_bg.Stop();
            m_Weapon.ChangeCanMove(false);
            m_FribeesManager.StopCreateFrisbee();            
        }

    }
}
