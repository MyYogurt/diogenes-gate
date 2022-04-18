using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class worldStorage
{
    public List<monsterObject> monsterList;
    public List<itemObject> itemsList;
    public List<pcObject> npclist;
    public int currentScene;
    public int lastScene;
    public Vector3 lastPosition;

    public worldStorage()
    {
        monsterList = new List<monsterObject>();
        itemsList = new List<itemObject>();
        npclist = new List<pcObject>();
    }
}
