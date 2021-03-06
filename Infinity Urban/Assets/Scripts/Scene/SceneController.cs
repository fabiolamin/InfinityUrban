﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void Play()
    {
        Time.timeScale = 1f;
    }

    public static void Stop()
    {
        Time.timeScale = 0f;
    }
    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public static void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public static void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public static void GameOver()
    {
        Time.timeScale = 0f;
        UIManager.isGameOver = true;
    }
}
