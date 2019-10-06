using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerClickHandler
{
    AudioManager audioManager;

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager = gameObject.GetComponent<AudioManager>();
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        audioManager.PlaySoundEffect(1);
        HandleTouchEvent(this.gameObject.tag);
    }

    void HandleTouchEvent(string tag)
    {
            switch(tag)
            {
                case "Pause":
                SceneController.Stop();
                UIManager.isPaused = true;
                break;

                case "Resume":
                SceneController.Play();
                UIManager.isPaused = false;
                break;

                case "Restart":
                    SceneController.Restart();
                break;

                case "MainMenu":
                SceneController.MainMenu();
                break;

                case "Start":
                SceneController.StartGame();
                break;
            }
    }
}
