using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController gameInstance;
    public playerStorage playerDetails;

    private GameController()
    {

    }

    public static GameController getInstance()
    {
        if (gameInstance==null)
        {
            gameInstance = new GameController();
        }
        return gameInstance;
    }

}
