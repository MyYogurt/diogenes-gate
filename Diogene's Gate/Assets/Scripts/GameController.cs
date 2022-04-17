using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController
{
    private static GameController gameInstance;
    public playerStorage playerDetails;
    public worldStorage worldDetails;

    private GameController()
    {
        playerDetails = new playerStorage();
        worldDetails = new worldStorage();
    }

    public static GameController getInstance()
    {
        if (gameInstance==null)
        {
            gameInstance = new GameController();
            string json = File.ReadAllText("Assets/Scripts/Data/json/newParty.txt");
            gameInstance.playerDetails = JsonUtility.FromJson<playerStorage>(json);

            string json2 = File.ReadAllText("Assets/Scripts/Data/json/newWorld.txt");
            gameInstance.worldDetails = JsonUtility.FromJson<worldStorage>(json2);
        }
        return gameInstance;
    }

    public static GameController loadInstance()
    {
        if (gameInstance == null)
        {
            gameInstance = new GameController();
            string json = File.ReadAllText("Assets/Scripts/Data/json/loadParty.txt");
            gameInstance.playerDetails = JsonUtility.FromJson<playerStorage>(json);

            string json2 = File.ReadAllText("Assets/Scripts/Data/json/loadWorld.txt");
            gameInstance.worldDetails = JsonUtility.FromJson<worldStorage>(json2);
        }
        return gameInstance;
    }

    public void loadInstence()
    {

    }

    public void newInstance()
    {

    }

}
