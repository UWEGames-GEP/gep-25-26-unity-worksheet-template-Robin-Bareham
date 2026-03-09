using System;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject pause_screen;
    public GameObject inventory_screen;
    public GameObject items_container;
    public enum GameState { GAMEPLAY,PAUSE,INVENTORY}
    private GameState state = GameState.GAMEPLAY;
    private bool hasChangedState = false;
    private bool first_inventory_open = false;
    private int items_dropped = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // Update is called once per frame
    void Update()
    {    }

    private void LateUpdate()
    {
        if (hasChangedState) 
        {
            hasChangedState = false;
            if (state == GameState.GAMEPLAY) 
            {
                Time.timeScale = 1.0f;
            }
            if(state == GameState.PAUSE || state == GameState.INVENTORY)
            {
                Time.timeScale = 0.0f;
            }
        }
    }
    private void OnMouseDown()
    {
        print("MOUSEDOWN");
    }
    public GameState getState() { return state; }

    public void inventoryInput()
    {
        switch (state) 
        {
            case GameState.GAMEPLAY:
                //Activate Inventory Canvas
                hasChangedState = true;
                state = GameState.INVENTORY;
                inventory_screen.SetActive(true);
                //If it's the first time the inventory has been activated, it gets the amount of buttons and pannels it has for sorting to work.
                if (!first_inventory_open)
                {
                    items_container.GetComponent<InventoryManagement>().loadLists();
                    first_inventory_open = true;
                }
                //Activates the buttons based on the items in the inventory.
                items_container.GetComponent<InventoryManagement>().sortBtnList(); //items_container.GetComponent<InventoryManagement>(). getItemList()); 
                //Activates cursor for clicking the buttons
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
            case GameState.INVENTORY:
                //Deactivates Inventory Canvas
                hasChangedState = true;
                state = GameState.GAMEPLAY;
                inventory_screen.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                items_dropped = 0;
                break;
        }
    }
    public void pauseInput()
    {

        switch (state)
        {
            case GameState.GAMEPLAY:
                //Activates Pause Canvas
                    hasChangedState = true;
                    state = GameState.PAUSE;
                    pause_screen.SetActive(true);
                //Unlocks mouse
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
            case GameState.PAUSE:
                //Deactivates Pause Canvas
                    hasChangedState = true;
                    state = GameState.GAMEPLAY;
                    pause_screen.SetActive(false);
                //Locks Cursor
                Cursor.visible = false ;
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case GameState.INVENTORY:
                //Deactivates Inventory Canvas
                    hasChangedState = true;
                    state = GameState.GAMEPLAY;
                    inventory_screen.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    items_dropped = 0;
                break;
        }

    }

    public void increase_dropped_no() 
    {
        items_dropped++;
    }

    public int get_dropped_no() 
    {
        return items_dropped;
    }
}
