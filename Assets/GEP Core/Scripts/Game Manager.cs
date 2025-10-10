using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { GAMEPLAY,PAUSE}
    public GameState state = GameState.GAMEPLAY;
    public GameObject pause_screen;
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

                }
                break;
            case GameState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    hasChangedState = true;
                    state = GameState.GAMEPLAY;
                    pause_screen.SetActive(false);
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
            if(state == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
            }
        }
    }
}
