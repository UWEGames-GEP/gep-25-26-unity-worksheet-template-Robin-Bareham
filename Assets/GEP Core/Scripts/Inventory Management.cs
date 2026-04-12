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

    public GameObject player_object;

    [SerializeField]
    private List<GameObject> buttons_list = new List<GameObject>();
    [SerializeField]
    private List<GameObject> object_list = new List<GameObject>();

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
        object_list.Add(item_icon);
    }

    public void removeItemFromInventory(GameObject button_clicked)
    {
        //Find which object it's referring to and decrease count for button.
        for (int i = 0; i < object_list.Count; i++)
        {
            if (object_list[i].GetComponent<Item>().getItemName() == button_clicked.GetComponentInChildren<PanelInfo>().getName()) 
            {

                //Debug.Log(player_object.transform.position + " " + object_list[i].transform.position);
                //Debug.Log(player_object.transform.forward.x + " " + player_object.transform.forward.z);
                //Debug.Log(Random.Range(-3f, 3f));

                //Change the location of the item being dropped to in front of where player is looking
                Vector3 position;
                position.x = (player_object.transform.position.x + 3 * player_object.transform.forward.x) + Random.Range(-2f, 2f);
                position.y = object_list[i].transform.position.y;
                position.z = (player_object.transform.position.z + 3 * player_object.transform.forward.z) + Random.Range(-2f, 2f);

                object_list[i].transform.position = position;

                object_list[i].SetActive(true);
                object_list.RemoveAt(i);
            }
        }

            //Make that object visible and remove from object list

            sortBtnList();

    }

    public void sortBtnList() 
    {
        //Debug.Log(buttons_list.Count);
        //Debug.Log(object_list.Count);
        for(int i = 0;i < buttons_list.Count; i++) 
        {
            buttons_list[i].SetActive(false);
            buttons_list[i].GetComponentInChildren<PanelInfo>().setCount(1);
            buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "1";
        }
        //Goes through all the objects collected
        for(int i = 0; i < object_list.Count; i++) 
        {
            //Goes through all the buttons
            //Debug.Log(object_list[i].GetComponent<Item>().getItemName());
            for (int j = 0; j < buttons_list.Count; j++)
            {
                //Debug.Log("Button: " + j);
                //Debug.Log("Button Name: " + buttons_list[j].GetComponentInChildren<PanelInfo>().getName() + " Item Name: " + object_list[i].GetComponent<Item>().getItemName());
                //If the button is active
                if (buttons_list[j].activeInHierarchy == true)
                {
                    if (buttons_list[j].GetComponentInChildren<PanelInfo>().getName() == object_list[i].GetComponent<Item>().getItemName())
                    {
                        int temp_num = int.Parse(buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
                        temp_num += 1;
                        buttons_list[j].GetComponentInChildren<PanelInfo>().setCount(temp_num);
                        buttons_list[j].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = temp_num.ToString();
                        break;
                    }
                }
                //If it's not active add object's Icon to the texture.
                else
                {
                    buttons_list[j].GetComponent<Image>().sprite = object_list[i].GetComponent<Item>().get2DIcon();
                    buttons_list[j].GetComponentInChildren<PanelInfo>().setName(object_list[i].GetComponent<Item>().getItemName());
                    buttons_list[j].GetComponentInChildren<PanelInfo>().setCount(1);
                    buttons_list[j].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "1";
                    buttons_list[j].SetActive(true);
                    break;
                }
            }
        }

    }

    //public void addObjectToList(GameObject temp_obj)
    //{
    //    object_list.Add(temp_obj);
    //}

}

