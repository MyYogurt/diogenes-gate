using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int window;
    public int selected;
    GameObject partyWindow;
    GameObject inventoryWindow;

    void Start()
    {
        selected = -1;
        window = 0;
        partyWindow = GameObject.Find("party");
        inventoryWindow = GameObject.Find("inventory");
        set();      
    }

    public void set()
    {
        GameController curr = GameController.getInstance();
        int j = 0;
        int i = curr.playerDetails.partySize();
        GameObject originalGameObject = GameObject.Find("CharList");
        while (j < 6)
        {
            pcObject temp = curr.playerDetails.partyMem(j);
            GameObject child = originalGameObject.transform.GetChild(j).gameObject;

            if (temp != null)
            {
                child.GetComponentInChildren<TextMeshProUGUI>().text = temp.pcName;
            }
            else
            {
                child.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }

            j++;
        }
        if(selected!=-1)
        {
            originalGameObject = GameObject.Find("charDesc");
            pcObject temp = curr.playerDetails.partyMem(selected);
            if (temp != null)
            {
                string output = "Class:" + "\nName: " + temp.pcName + "\nDefense: " + temp.dodge + "\nHealth:    " + temp.health + "\nMana:     " + temp.mana;
                originalGameObject.GetComponentInChildren<TextMeshProUGUI>().text = output;

                GameObject child = originalGameObject.transform.Find("helm").gameObject;
                if (temp.armor[0] != null)
                {
                    child.GetComponentInChildren<TextMeshProUGUI>().text = temp.armor[0].itemName;
                }
                else
                {
                    child.GetComponentInChildren<TextMeshProUGUI>().text = "nothing";
                }

                child = originalGameObject.transform.Find("weapon").gameObject;
                if (temp.armor[1] != null)
                {
                    child.GetComponentInChildren<TextMeshProUGUI>().text = temp.armor[1].itemName;
                }
                else
                {
                    child.GetComponentInChildren<TextMeshProUGUI>().text = "nothing";
                }

                child = originalGameObject.transform.Find("armor").gameObject;
                if (temp.armor[2] != null)
                {
                    child.GetComponentInChildren<TextMeshProUGUI>().text = temp.armor[2].itemName;
                }
                else
                {
                    child.GetComponentInChildren<TextMeshProUGUI>().text = "nothing";
                }
            }
        }
    }




    public void onNameClick(int a)
    {
        selected = a;
        set();
    }

    public void onSwapClick(int a)
    {
        window = a;
        GameController curr = GameController.getInstance();

        if (window == 1)
        {
           partyWindow.SetActive(false);
           inventoryWindow.SetActive(true);
        }
        else
        {

            partyWindow.SetActive(true);
            inventoryWindow.SetActive(false);

        }
 
    }

    public void onArmorClick(int a)
    {
        GameController curr = GameController.getInstance();
        GameObject originalGameObject = GameObject.Find("charDesc");
        pcObject temp = curr.playerDetails.partyMem(selected);
        if (temp != null)
        {
            itemObject remove = temp.armor[a];
            temp.armor[a] = null;
            Debug.Log(remove.itemName);
            curr.playerDetails.addItem(remove);

        }
        set();
    }

    public void onInvClick(int a)
    {
        GameController curr = GameController.getInstance();
        GameObject originalGameObject = GameObject.Find("charDesc");
        pcObject temp = curr.playerDetails.partyMem(a);
        if (temp != null)
        {
            string output = "Class:" + "\nName: " + temp.pcName + "\nDefense: " + temp.dodge + "\nHealth: " + temp.health + "\nMana: " + temp.mana;
            originalGameObject.GetComponentInChildren<TextMeshProUGUI>().text = output;
        }
    }

}
