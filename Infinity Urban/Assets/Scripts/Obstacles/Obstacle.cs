using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    ScoreManager scoreManager;
    AudioManager audioManager;

    private void Start()
    {
        GameObject gameObjectAux = GameObject.FindGameObjectWithTag("ScoreManager");
        scoreManager = gameObjectAux.GetComponent<ScoreManager>();

        GameObject gameObjectAux2 = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager = gameObjectAux2.GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audioManager.StopMusic();
            audioManager.PlaySoundEffect(2);
            scoreManager.CalculateHighScore();
            SceneController.Stop();
            UIManager.isGameOver = true;
        }
    }
}
