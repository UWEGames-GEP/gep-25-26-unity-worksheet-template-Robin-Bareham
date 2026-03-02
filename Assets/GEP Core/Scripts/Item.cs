using UnityEngine;

public class Item : MonoBehaviour
{
    public Texture2D item_icon;
    public BoxCollider box_collider;
    public GameObject item_prefab;

    private bool active_in_inventory = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ack!");
        if (!active_in_inventory) 
        {
            item_prefab.SetActive(false);
        }
    }

    public void set_active(bool active) 
    {
        active_in_inventory = active;
    }

    public bool get_active() 
    {
        return active_in_inventory;
    }

    public Texture2D get_icon() 
    {
        return item_icon;
    }
}
