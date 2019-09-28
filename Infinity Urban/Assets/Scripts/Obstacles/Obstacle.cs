using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    ScoreManager scoreManager;

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("ScoreManager");
        scoreManager = gameObject.GetComponent<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            scoreManager.CalculateHighScore();
            SceneController.GameOver();
        }
    }
}
