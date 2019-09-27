using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void Play()
    {
        
    }
    public static void Pause()
    {
        Time.timeScale = 0f;
        UIManager.isPaused = true;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        UIManager.isPaused = false;
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public static void GameOver()
    {
        Time.timeScale = 0f;
        UIManager.isGameOver = true;
    }
}
