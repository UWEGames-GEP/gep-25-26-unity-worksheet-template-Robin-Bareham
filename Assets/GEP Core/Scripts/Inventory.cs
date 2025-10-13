using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gameManager;

    [SerializeField]
    private List<string> items = new List<string>();
    

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
        if (Input.GetKeyDown(KeyCode.Alpha2) && gameManager.getState() == GameManager.GameState.GAMEPLAY)
        {
            addItem("Banana");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && gameManager.getState() == GameManager.GameState.GAMEPLAY)
        {
            addItem("Pair");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && gameManager.getState() == GameManager.GameState.GAMEPLAY)
        {
            addItem("Melon");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && gameManager.getState() == GameManager.GameState.GAMEPLAY) 
        {
            removeItem("Apple");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && gameManager.getState() == GameManager.GameState.GAMEPLAY)
        {
            removeItem("Banana");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && gameManager.getState() == GameManager.GameState.GAMEPLAY)
        {
            removeItem("Pair");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8) && gameManager.getState() == GameManager.GameState.GAMEPLAY)
        {
            removeItem("Melon");

        }
    }

    public void addItem(string item_name)
    {
        items.Add(item_name);
        sortList();
    }

    public void removeItem(string item_name) 
    {
        items.Remove(item_name);
    }

    private void sortList() 
    {
        items.Sort();
    }

}
