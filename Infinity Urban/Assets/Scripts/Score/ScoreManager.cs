using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector]
    public int scoreValue;
    [HideInInspector]
    public bool isUpdatingScore;
    void Start()
    {
        isUpdatingScore = true;
        scoreValue = 0;
    }

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        if (isUpdatingScore)
        {
            scoreValue += (int)Time.time;
        }
    }

    public void CalculateHighScore()
    {
        if (scoreValue > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", scoreValue);
        }
    }
}
