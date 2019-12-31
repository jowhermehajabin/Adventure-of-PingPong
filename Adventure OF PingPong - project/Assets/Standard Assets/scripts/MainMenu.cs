﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Text highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString(); 
    }

    
    public void  ToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
