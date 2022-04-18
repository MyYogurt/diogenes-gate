using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

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
        pcObject find = Party.FirstOrDefault(x => x.pcName == newMem.pcName);
        if (find != null)
        {
            Party.Add(newMem);
        }
        return;
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
        if (i!=-1 && Party!=null && i < partySize())
            return Party[i];
        else
            return null;
    }
    public pcObject partyMem(string i)
    {
        pcObject find = Party.FirstOrDefault(x => x.pcName == i);
        if (find != null)
        {
            return find;
        }
        return null;
    }



    //inventory management
    public void addItem(itemObject item)
    {
        if(item == null)
        {
            return;
        }
        Debug.Log(item.itemName);
        itemObject find = inventory.FirstOrDefault(x => x.itemName == item.itemName);
        if (find!=null)
        {
            find.number += 1;
        }
        else
        {
            item.number = 1;
            inventory.Add(item);
        }
    }
    public void removeItem(itemObject item)
    {
        if (item == null)
        {
            return;
        }
        itemObject find = inventory.FirstOrDefault(x => x.itemName == item.itemName);
        if (find != null)
        {
            find.number -= 1;
            if (find.number == 0)
            {
                inventory.Remove(item);
            }
        }
    }
    public itemObject invMem(int i)
    {
        if (inventory != null && i < inventory.Count)
            return inventory[i];
        else
            return null;
    }
}
