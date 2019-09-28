using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text txtScore;
    public GameObject imgGameOver;
    public Text txtScoreGameOver;
    public GameObject imgScore;
    public GameObject btnPause;
    public GameObject btnResume;
    public GameObject btnRestart;
    public GameObject btnQuit;
    public static bool isPaused;
    public static bool isGameOver;
    public static bool wasRestarted;
    public Text txtPause;
    public ScoreManager scoreManager;
    private void Start()
    {
        isPaused = false;
        isGameOver = false;
        wasRestarted = false;
        imgScore.SetActive(true);
        btnPause.SetActive(true);
        btnResume.SetActive(false);
        btnRestart.SetActive(false);
        btnQuit.SetActive(false);
        txtPause.enabled = false;
        imgGameOver.SetActive(false);
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
        btnResume.SetActive(true);
        btnRestart.SetActive(true);
        btnQuit.SetActive(true);
        txtPause.enabled = true;
    }

    void Resume()
    {
        scoreManager.isUpdatingScore = true;
        btnPause.SetActive(true);
        btnResume.SetActive(false);
        btnRestart.SetActive(false);
        btnQuit.SetActive(false);
        txtPause.enabled = false;
    }

    void GameOver()
    {
        scoreManager.isUpdatingScore = false;
        btnPause.SetActive(false);
        imgScore.SetActive(false);
        btnRestart.SetActive(false);
        btnQuit.SetActive(false);
        imgGameOver.SetActive(true);
        txtScoreGameOver.text = scoreManager.scoreValue.ToString();
    }
}
