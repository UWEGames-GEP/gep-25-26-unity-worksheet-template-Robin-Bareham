using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine.EventSystems;

public class Inventory : Items //MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private List<GameObject> buttons_list = new List<GameObject>(); //List of all the buttons in the inventory
    private List<GameObject> panel_list = new List<GameObject>(); //List of all the avalible panels for items to into

    public void logAllBtns() 
    {
        //Fills lists with the items depending on their tag
        GameObject[] btn = GameObject.FindGameObjectsWithTag("invBtn");
        GameObject[] pannel_temp = GameObject.FindGameObjectsWithTag("pannel");
        //Adds the buttons and pannels to their respective lists.
        for (int i = 0; i < btn.Length; i++)
        {
            buttons_list.Add(btn[i]);
            buttons_list[i].SetActive(false);
        }
        for (int i = 0; i < pannel_temp.Length; i++)
        {
            panel_list.Add(pannel_temp[i]);
        }
       
    }

    public void activate_buttons(List<string> collected_list)
    {
        //Sets all the buttons to false, invisible.
        for (int i = 0; i < buttons_list.Count; i++)
        {
            buttons_list[i].SetActive(false);
        }
        //Goes through all avalible buttons
        for (int i = 0; i < buttons_list.Count; i++)
        {
            //How many of that item is in the inventory
            int object_count = 0;
            //Decide to avoid hiding an object if it's in the list.
            bool already_activated = false;
            //Goes through the list of collected items
            for (int j = 0; j < collected_list.Count; j++)
            {

                //if a button name is in the collected items
                if (buttons_list[i].name == collected_list[j])
                {
                    //It sets it to active
                    buttons_list[i].SetActive(true);
                    already_activated = true; //Avoids hiding it when going through the rest of the list.
                    object_count++;
                }
                //If there is no instance of the button and it hasn't been set to active in a different part.
                else if (!already_activated)
                {
                    buttons_list[i].SetActive(false);
                }
            }
            //Updates the amount of the objects left in the inventory on that button's text.
            buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = object_count.ToString();

        }
        sortBtnList();
    }

    private void sortBtnList()
    {
        //Reset first button position to match first panel.
        int current_panel = 0;
        int max_panels = panel_list.Count;
        //Goes through the list of buttons
        for (int i = 0; i < buttons_list.Count; i++)
        {
            //If the current button is visible (Active)
            if (buttons_list[i].activeInHierarchy == true)
            {
                //Get Current Panel position
                UnityEngine.Vector3 panel_pos = panel_list[current_panel].transform.position;
                //Set active button to current panel position
                buttons_list[i].transform.position = panel_pos;
                //Makes it so next panel will the selected.
                current_panel++;
            }
        }

    }

    public void removeItemFromInventory(string item_name) 
    {
        removeItem(item_name);
        activate_buttons(getItemList());
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //If the player collides with an active object with the tag collectable.
        if (hit.transform.CompareTag("Collectable") && hit.gameObject.activeSelf == true) 
        {
            getGameObjectList().Add(hit.gameObject);
            getItemList().Add(hit.gameObject.name);
            hit.gameObject.SetActive(false);
            Debug.Log("YOU@VE COLLECTED SOMETHING");
            Debug.Log(getItemList().Count);
        }
    } 

}
