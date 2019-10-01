using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public ScoreManager scoreManager;
    public Text txtScore;
    public Text txtScoreGameOver;
    public GameObject panelGameOver;
    public GameObject panelPaused;
    public GameObject imgScore;
    public GameObject btnPause;
    public static bool isPaused;
    public static bool isGameOver;
    public static bool wasRestarted;
    
    private void Start()
    {
        isPaused = false;
        isGameOver = false;
        wasRestarted = false;
        imgScore.SetActive(true);
        btnPause.SetActive(true);
        panelPaused.SetActive(false);
        panelGameOver.SetActive(false);
    }

    void Update()
    {
        if(isPaused)
        {
            Pause();
        }

        else if(isGameOver)
        {
            GameOver();
        }

        else
        {
            Resume();
        }

        ShowScore();
    }

    void ShowScore()
    {
        txtScore.text = scoreManager.scoreValue.ToString();
    }

    void Pause()
    {
        scoreManager.isUpdatingScore = false;
        btnPause.SetActive(false);
        panelPaused.SetActive(true);
    }

    void Resume()
    {
        scoreManager.isUpdatingScore = true;
        btnPause.SetActive(true);
        panelPaused.SetActive(false);
    }

    void GameOver()
    {
        scoreManager.isUpdatingScore = false;
        btnPause.SetActive(false);
        imgScore.SetActive(false);
        panelGameOver.SetActive(true);
        txtScoreGameOver.text = scoreManager.scoreValue.ToString();
    }
}
