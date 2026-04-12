using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public GameObject inventory_manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //If the player collides with an active object with the tag collectable.
        if (hit.transform.CompareTag("Collectable") && hit.gameObject.activeSelf == true)
        {
            hit.gameObject.GetComponent<Item>().setInventoryActive(true);
            hit.gameObject.SetActive(false);

            inventory_manager.GetComponent<InventoryManagement>().addItemToInventory(hit.gameObject);
        }

    }
}
