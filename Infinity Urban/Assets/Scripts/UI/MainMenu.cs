using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text txtHighscore;
    void Start()
    {
        txtHighscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
