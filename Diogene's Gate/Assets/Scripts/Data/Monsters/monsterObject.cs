using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class monsterObject
{
    // Start is called before the first frame update
    public string monsterName;       
    public int dodge;    
    public int health;
    public int damage;
    public int numAttacks;


    public monsterObject()
    {
        monsterName = "slime";
        dodge = 3;
        health= 4;
        damage = 5;
        numAttacks= 1;
    }

    public bool Equals(monsterObject other)
    {
        if (other == null)
        {
            return false;
        }

        if (string.Compare(this.monsterName, other.monsterName) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
