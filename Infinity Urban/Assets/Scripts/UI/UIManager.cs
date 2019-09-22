using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Text txtScore;
    public GameObject btnPause;
    public GameObject btnResume;
    public GameObject btnRestart;
    public GameObject btnQuit;
    public static bool isPaused;
    public static bool wasRestarted;
    public Text txtPause;

    private void Start()
    {
        isPaused = false;
        wasRestarted = false;
        btnPause.SetActive(true);
        btnResume.SetActive(false);
        btnRestart.SetActive(false);
        btnQuit.SetActive(false);
        txtPause.enabled = false;
    }

    void Update()
    {
        if(isPaused)
        {
            Pause();
        }

        else
        {
            Resume();
        }

        ShowScore();
    }

    void ShowScore()
    {
        txtScore.text = player.score.ToString();
    }

    void Pause()
    {
        player.isUpdatingScore = false;
        btnPause.SetActive(false);
        btnResume.SetActive(true);
        btnRestart.SetActive(true);
        btnQuit.SetActive(true);
        txtPause.enabled = true;
    }

    void Resume()
    {
        player.isUpdatingScore = true;
        btnPause.SetActive(true);
        btnResume.SetActive(false);
        btnRestart.SetActive(false);
        btnQuit.SetActive(false);
        txtPause.enabled = false;
    }
}
