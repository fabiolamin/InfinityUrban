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
                    SceneController.Pause();
                break;

                case "Resume":
                    SceneController.Resume();
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
