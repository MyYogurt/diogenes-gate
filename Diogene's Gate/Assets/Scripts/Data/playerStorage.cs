using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class playerStorage 
{
    public List<pcObject> Party;
    public List<itemObject> inventory;

    public playerStorage()
    {
        Party = new List<pcObject>();
        inventory = new List<itemObject>();
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
    public int partySize()
    {
        return Party.Count;
    }
    public pcObject partyMem(int i)
    {
        if (Party!=null && i < partySize())
            return Party[i];
        else
            return null;
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
