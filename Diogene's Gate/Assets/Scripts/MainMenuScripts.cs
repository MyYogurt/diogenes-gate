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

        // then load town with the scene change
        newgame.worldDetails.lastScene = 0;
        newgame.worldDetails.currentScene = 2;
        SceneManager.LoadScene("town");
        newgame.worldDetails.lastPosition = new Vector3(389.49f, -35.89f, 0);
    }

    public void loadGame()
    {
        GameController newgame = GameController.loadInstance();
        SceneManager.LoadScene(newgame.worldDetails.currentScene);
        //SceneManager.LoadScene("town");
        //need to figure out instance
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
