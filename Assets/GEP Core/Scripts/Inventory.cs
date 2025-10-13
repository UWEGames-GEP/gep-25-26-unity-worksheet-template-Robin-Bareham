using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public List<string> items = new List<string>();
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameManager.getState() == GameManager.GameState.GAMEPLAY)
        {
            addItem("Apple");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && gameManager.getState() == GameManager.GameState.GAMEPLAY) 
        {
            removeItem("Apple");
        }
    }

    void addItem(string item_name)
    {
        items.Add(item_name);
    }

    void removeItem(string item_name) 
    {
        items.Remove(item_name);
    }

}
