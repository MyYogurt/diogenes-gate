using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStorage : MonoBehaviour
{
    private List<pcObject> Party = new List<pcObject>();
    private List<itemObject> inventory = new List<itemObject>();

    public void preLoad() // start game pass in a storage device
    {

    }



    // party management.
    // first 3 are the active party
    public void addParty(pcObject newMem)
    {
        if(Party.Contains(newMem))
        {
            return;
        }
        Party.Add(newMem);
    }
    public void swapParty(int slot1, int slot2)
    {
        pcObject temp = Party[slot1];
        Party[slot1] = Party[slot2];
        Party[slot2] = temp;
    }



    //inventory management
    public void addItem(itemObject item)
    {
        if(item == null)
        {
            return;
        }
        if (inventory.Contains(item))
        {
            inventory.Find(a => inventory.Contains(item)).number=+1;
        }
        else
        {
            inventory.Add(item);
        }
    }
    public void removeItem(itemObject item)
    {
        if (item == null)
        {
            return;
        }
        if (inventory.Contains(item))
        {
            inventory.Find(a => inventory.Contains(item)).number = -1;
            if (inventory.Find(a => inventory.Contains(item)).number == 0)
            {
                inventory.Remove(item);
            }
        }
    }
}
