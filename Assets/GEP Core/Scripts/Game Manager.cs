using System;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject pause_screen;
    public GameObject inventory_screen;
    public GameObject player_inventory;
    public enum GameState { GAMEPLAY,PAUSE,INVENTORY}
    private GameState state = GameState.GAMEPLAY;
    private bool hasChangedState = false;
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
                //Activates the buttons based on the items in the inventory.
                inventory_screen.GetComponent<SortingInventory>().activate_buttons(player_inventory.GetComponent<Inventory>().getList());
                //Activates cursor for clicking the buttons
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
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
                break;
        }

    }
}
