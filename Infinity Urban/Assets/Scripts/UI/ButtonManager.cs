using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerClickHandler
{
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
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

                case "Quit":
                    SceneController.Quit();
                break;
            }
    }
}
