using NUnit.Framework;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class SortingInventory : MonoBehaviour
{
    public List<GameObject> buttons_list = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("invBtn");

        for (int i = 0; i < btn.Length; i++)
        {
            buttons_list.Add(btn[i]);
            buttons_list[i].SetActive(false);
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
        
        for (int i = 0; i < buttons_list.Count; i++) 
        {
            bool already_activated = false;
            for (int j = 0; j < collected_list.Count; j++) 
            {
                if (buttons_list[i].name == collected_list[j]) 
                {
                    buttons_list[i].SetActive(true);
                    already_activated = true;
                }
                else if (!already_activated)
                {
                    buttons_list[i].SetActive(false);
                }
            }
        }
    }
}
