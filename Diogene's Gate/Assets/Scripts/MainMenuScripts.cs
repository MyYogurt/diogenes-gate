﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public void newGame()
    {
        //need to figure out instance
        GameController newgame = GameController.getInstance();

        // then load town with the scene change
        SceneManager.LoadScene("Ingame_Menu");
    }

    public void loadGame()
    {
        GameController newgame = GameController.loadInstance();
        SceneManager.LoadScene("Ingame_Menu");
        //need to figure out instance
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
