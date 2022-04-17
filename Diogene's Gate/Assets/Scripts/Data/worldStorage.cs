using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class worldStorage
{
    public int loc; //pre determind spawn locations (changes every time we change scenes)
    public List<monsterObject> monsterList;
    public List<itemObject> itemsList;
    public List<pcObject> npclist;

    public worldStorage()
    {
        loc = 0;
        monsterList = new List<monsterObject>();
        itemsList = new List<itemObject>();
        npclist = new List<pcObject>();
    }


}
