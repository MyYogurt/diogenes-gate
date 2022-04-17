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
    public int item;
    GameObject partyWindow;
    GameObject inventoryWindow;

    void Start()
    {
        selected = -1;
        window = 0;
        partyWindow = GameObject.Find("party");
        inventoryWindow = GameObject.Find("inventory");
        setParty();      
    }

    public void setParty()
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


    public void setInven()
    {
        GameController curr = GameController.getInstance();

        GameObject originalGameObject = GameObject.Find("inventory");
        int j = 0;
        while (j < 7)
        {
            itemObject temp = curr.playerDetails.invMem(j);
            GameObject child = originalGameObject.transform.Find("slots").transform.GetChild(j).gameObject;

            if (temp != null)
            {
                child.GetComponentInChildren<TextMeshProUGUI>().text = temp.itemName;
            }
            else
            {
                child.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }

            j++;
        }

    }

    public void onNameClick(int a)
    {
        selected = a;
        setParty();
    }

    public void onSwapClick(int a)
    {
        window = a;
        GameController curr = GameController.getInstance();

        if (window == 1)
        {
           partyWindow.SetActive(false);
           inventoryWindow.SetActive(true);
           setInven();
        }
        else
        {

            partyWindow.SetActive(true);
            inventoryWindow.SetActive(false);
            setParty();
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
            curr.playerDetails.addItem(remove);

        }
        setParty();
    }

    public void onInvClick(int a)
    {
        GameController curr = GameController.getInstance();

        itemObject temp = curr.playerDetails.invMem(a);

        GameObject originalGameObject = GameObject.Find("inventory");
        GameObject child = originalGameObject.transform.Find("useMenu").transform.Find("Dropdown").gameObject;
        child.GetComponentInChildren<TMP_Dropdown>().ClearOptions();
        int j = 0;
        List<string> L= new List<string>();
        while (j < 6)
        {
            pcObject pc = curr.playerDetails.partyMem(j);
            if (pc!=null)
            {
                string cha = pc.pcName;
                L.Add(cha);
            }
            j++;
        }
        child.GetComponentInChildren<TMP_Dropdown>().AddOptions(L);



        child = originalGameObject.transform.Find("useMenu").transform.Find("description").gameObject;
        if (temp != null)
        {
            string s;
            if(temp.type==4)//heal
            {
                s ="\nHeals: " + temp.value;
            }
            else if (temp.type == 3)//mana
            {
                s = "\nMana gained: " + temp.value;
            }
            else if(temp.type ==1 || temp.type == 2)//defense
            {
                s = "\nDefense: " + temp.value;
            }
            else
            {
                s = "\nDamage: " + temp.value;
            }
            string output = "Name: " + temp.itemName + "\nConsumable: " + temp.destroyOnUse + s + "\ncarried: " + temp.number;
            child.GetComponentInChildren<TextMeshProUGUI>().text = output;

        }
        child = originalGameObject.transform.Find("useMenu").gameObject;
        child.transform.position = new Vector3(703, 401, 0);



    }

    public void onUseClick(int a)
    {
        GameObject originalGameObject = GameObject.Find("inventory");
        GameObject child = originalGameObject.transform.Find("useMenu").transform.Find("Dropdown").gameObject;
        if (a==0)
        {

        }

        child = originalGameObject.transform.Find("useMenu").gameObject;
        child.transform.position = new Vector3(-420, 200, 0);
    }

}
