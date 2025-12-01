using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class PlayerCharControler : ThirdPersonController
{
    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        { gameManager.pauseInput(); }
    }
    private void OnInventory(InputValue value)
    {
        if (value.isPressed)
        { gameManager.inventoryInput(); }
    }
}
