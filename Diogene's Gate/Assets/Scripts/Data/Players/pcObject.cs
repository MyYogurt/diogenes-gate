using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class pcObject
{
    // Start is called before the first frame update
    public string pcName;
    public int dodge;
    public int health;
    public int healthLeft;
    public int mana;
    public int manaLeft;
    public itemObject[] armor;
    public List<skillObject> skills;

    public pcObject()
    {
        pcName = "doug";
        dodge = 3;
        health = 4;
        healthLeft = 4;
        mana = 5;
        manaLeft = 5;
        armor = new itemObject[3];
        skills = new List<skillObject>();
    }

    public bool Equals(pcObject other)
    {
        if (other == null)
        {
            return false;
        }

        if (string.Compare(this.pcName, other.pcName) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
