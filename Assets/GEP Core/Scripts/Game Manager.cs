using System;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject pause_screen;
    public GameObject inventory_screen;
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
    {
        switch (state) 
        {
            case GameState.GAMEPLAY:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    hasChangedState = true;
                    state = GameState.PAUSE;
                    pause_screen.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    hasChangedState = true;
                    state = GameState.INVENTORY;
                    inventory_screen.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case GameState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    hasChangedState = true;
                    state = GameState.GAMEPLAY;
                    pause_screen.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    print("MOUSE DOWN");
                }
                else if (Input.GetMouseButtonDown(1)) 
                {
                    print("MOUSE UP");
                }
                break;
            case GameState.INVENTORY:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    hasChangedState = true;
                    state = GameState.GAMEPLAY;
                    inventory_screen.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
        }
    }

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
        switch (state)
        {
            case GameState.INVENTORY:
                
                break;
        }
        print("MOUSEDOWN");
    }
    public GameState getState() { return state; }
}
