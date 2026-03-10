using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InventoryManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]

    private List<GameObject> buttons_list = new List<GameObject>();
    [SerializeField]
    private List<GameObject> object_list = new List<GameObject>();
    [SerializeField]
    private List<string> icon_list = new List<string>();

    public void loadLists() 
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("invBtn");
        //GameObject[] obj = GameObject.FindGameObjectsWithTag("Collectable");

        for (int i = 0; i < btn.Length; i++)
        {
            buttons_list.Add(btn[i]);
            buttons_list[i].SetActive(false);
        }
    }

    public void addItemToInventory(GameObject item_icon)
    {
        //Adds physical object to list and get the name assiosiated with it.
        object_list.Add(item_icon);
        //icon_list.Add(item_icon.GetComponent<Item>().getItemName());
    }

    public void removeItemFromInventory(GameObject p_object)
    {
        ////Finds button it's representing, decreases count.
        //for(int i=0; i<buttons_list.Count; i++) 
        //{
        //    if (buttons_list[i].activeInHierarchy == true)
        //    {
        //        if (buttons_list[i].GetComponent<Image>().sprite == p_object.GetComponent<Item>().get2DIcon())
        //        {
        //            int temp_num = int.Parse(buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
        //            temp_num -= 1;
        //            buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = temp_num.ToString();

        //        }
        //    }
        //}
        ////removes icon from list
        //for (int i = 0; i < icon_list.Count; i++)
        //{
        //    if (icon_list[i] == item_icon)
        //    {
        //        icon_list.Remove(icon_list[i]);
        //    }
        //}
        ////Finds icon's item
        //for (int i = 0; i < object_list.Count; i++)
        //{
        //    if (object_list[i].GetComponent<Item>().getInventoryActive() == true && object_list[i].GetComponent<Item>().get2DIcon() == item_icon)
        //    {
        //        object_list[i].SetActive(true);
        //        object_list[i].GetComponent<Item>().setInventoryActive(false);
        //    }
        //}
        //sortBtnList();

    }

    public void sortBtnList() 
    {
        //Debug.Log(buttons_list.Count);
        //Debug.Log(object_list.Count);
        for(int i = 0;i < buttons_list.Count; i++) 
        {
            buttons_list[i].SetActive(false);
        }
        //Goes through all the objects collected
        for(int i = 0; i < object_list.Count; i++) 
        {
            //Goes through all the buttons
            Debug.Log(object_list[i].GetComponent<Item>().getItemName());
            for (int j = 0; j < buttons_list.Count; j++)
            {
                Debug.Log("Button: " + j);
                Debug.Log("Button Name: " + buttons_list[j].GetComponentInChildren<PanelInfo>().getName() + " Item Name: " + object_list[i].GetComponent<Item>().getItemName());
                //If the button is active
                if (buttons_list[j].activeInHierarchy == true)
                {
                    if (buttons_list[j].GetComponentInChildren<PanelInfo>().getName() == object_list[i].GetComponent<Item>().getItemName())
                    {
                        int temp_num = int.Parse(buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
                        temp_num += 1;
                        buttons_list[j].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = temp_num.ToString();
                        break;
                    }
                }
                //If it's not active add object's Icon to the texture.
                else
                {
                    buttons_list[j].GetComponent<Image>().sprite = object_list[i].GetComponent<Item>().get2DIcon();
                    buttons_list[j].GetComponentInChildren<PanelInfo>().setName(object_list[i].GetComponent<Item>().getItemName());
                    buttons_list[j].SetActive(true);
                    break;
                }
            }
        }

    }

    public void addObjectToList(GameObject temp_obj)
    {
        object_list.Add(temp_obj);
    }

}

