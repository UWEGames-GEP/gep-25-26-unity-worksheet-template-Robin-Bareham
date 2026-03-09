using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite item_icon;
    private bool active_in_inventory = false;

    public void setInventoryActive(bool active) 
    {
        active_in_inventory = active;
    }
    public bool getInventoryActive()
    {
        return active_in_inventory;
    }
    public Sprite get2DIcon() 
    {
        return item_icon;
    }
}
