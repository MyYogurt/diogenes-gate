using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "monster Card", menuName = "new Monster")]
public class monsterObject : ScriptableObject
{
    // Start is called before the first frame update
    public string monsterName;       
    public int dodge;    
    public int health;
    public int damage;
    public int numAttacks;

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
