using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenuScripts
{
    // Start is called before the first frame update
    public void newGame()
    {
        //need to figure out instance
        GameController newgame = GameController.getInstance();

        // then load town with the scene change
        //      SceneManager.LoadScene();
    }

    public void loadGame()
    {
        GameController newgame = GameController.loadInstance();
        //need to figure out instance
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
