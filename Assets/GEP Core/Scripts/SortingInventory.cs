using NUnit.Framework;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class SortingInventory : MonoBehaviour
{
    private List<GameObject> buttons_list = new List<GameObject>();
    private List<GameObject> panel_list = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("invBtn");
        GameObject[] pannel_temp = GameObject.FindGameObjectsWithTag("pannel");

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate_buttons(List<string> collected_list) 
    {
        //Sets all the buttons to false if there
        for (int i = 0; i < buttons_list.Count; i++)
        {
          buttons_list[i].SetActive(false);
        }
        //Goes through all avalible buttons
        for (int i = 0; i < buttons_list.Count; i++) 
        {
            int object_count = 0;
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
            buttons_list[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = object_count.ToString();
            //buttons_list[i].GetComponentInChildren<Text>().text = object_count.ToString();
        }
        sortBtnList(); 
    }

    private void sortBtnList() 
    {

        //Reset first button position.
        int current_panel = 0;
        int max_panels = panel_list.Count;
        //Checks if there is an active button.
        for (int i =0; i < buttons_list.Count; i++) 
        {
            if (buttons_list[i].activeInHierarchy == true) 
            {
                //Set its position to the first free pannel

                //Get Panel position
                UnityEngine.Vector3 panel_pos = panel_list[current_panel].transform.position;
                //Set active button to position
                buttons_list[i].transform.position = panel_pos;
                current_panel++;
                //Change the new starting position for the next possible button
            }
        }

    }


}