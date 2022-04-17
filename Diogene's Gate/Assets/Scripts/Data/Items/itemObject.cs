using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class itemObject
{
    public string itemName;               //    name
    public bool destroyOnUse;             //    Examples of additional information that could be held in InventoryItem
    public int value;                     //    Tied to how much defense, offense, etc is provided
    public int type;
    public int number;


    public bool Equals(itemObject other)
    {
        
        if (other == null)
        {
            return false;
        }

        if (string.Compare(this.itemName, other.itemName) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
