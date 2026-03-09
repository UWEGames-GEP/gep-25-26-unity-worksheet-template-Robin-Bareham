using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]

    private List<GameObject> buttons_list = new List<GameObject>();
    [SerializeField]
    private List<GameObject> object_list = new List<GameObject>();
    [SerializeField]
    private List<Sprite> icon_list = new List<Sprite>();

    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Collectable"); for (int i = 0; i < obj.Length; i++)
        {
            object_list.Add(obj[i]);
            object_list[i].SetActive(true);
        }
    }

    public void loadLists() 
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("invBtn");
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Collectable");

        for (int i = 0; i < btn.Length; i++)
        {
            buttons_list.Add(btn[i]);
            buttons_list[i].SetActive(false);
        }
        //for (int i = 0; i < obj.Length; i++)
        //{
        //    object_list.Add(obj[i]);
        //    object_list[i].SetActive(true);
        //}
    }

    public void addItemToInventory(Sprite item_icon)
    {
        icon_list.Add(item_icon);
        //Add to the next availble button.
        for (int i = 0; i < buttons_list.Count; i++)
        {
            if (buttons_list[i].activeInHierarchy)
            {
                if (buttons_list[i].GetComponent<Texture2D>() == item_icon)
                {
                    //Add 1 to count
                    break;
                }
            }
            else
            {
                buttons_list[i].GetComponent<Image>().sprite = item_icon;
                break;
            }
        }

    }

    public void removeItemFromInventory(Sprite item_icon)
    {
        //Finds button it's representing, decreases count.
        for(int i=0; i<buttons_list.Count; i++) 
        {
            if (buttons_list[i].activeInHierarchy == true)
            {
                if (buttons_list[i].GetComponent<Image>().sprite == item_icon)
                {
                    int temp_num = int.Parse(buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
                    temp_num -= 1;
                    buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = temp_num.ToString();

                }
            }
        }
        //removes icon from list
        for (int i = 0; i < icon_list.Count; i++)
        {
            if (icon_list[i] == item_icon)
            {
                icon_list.Remove(icon_list[i]);
            }
        }
        //Finds icon's item
        for (int i = 0; i < object_list.Count; i++)
        {
            if (object_list[i].GetComponent<Item>().getInventoryActive() == true && object_list[i].GetComponent<Item>().get2DIcon() == item_icon)
            {
                object_list[i].SetActive(true);
                object_list[i].GetComponent<Item>().setInventoryActive(false);
            }
        }
        sortBtnList();
    }

    public void sortBtnList() 
    {
        for(int i = 0;i < buttons_list.Count; i++) 
        {
            buttons_list[i].SetActive(false);
        }

        for(int i = 0; i < icon_list.Count; i++) 
        {
            for (int j = 0; j < buttons_list.Count; i++)
            {
                if (buttons_list[j].activeInHierarchy == true)
                {
                    if (buttons_list[j].GetComponent<Image>().sprite == icon_list[i])
                    {
                        int temp_num = int.Parse(buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
                        temp_num += 1;
                        buttons_list[j].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = temp_num.ToString();
                        break;
                    }
                }
                else
                {
                    buttons_list[j].GetComponent<Image>().sprite = icon_list[i];
                    buttons_list[j].SetActive(true);
                    break;
                }
            }
        }

    }

}

