using System.Collections;
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
        newgame.playerDetails.addParty((pcObject)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Data/Players/main character.asset", typeof(pcObject)));

        // then load town with the scene change
        //      SceneManager.LoadScene();
    }

    public void loadGame()
    {
        //need to figure out instance
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
