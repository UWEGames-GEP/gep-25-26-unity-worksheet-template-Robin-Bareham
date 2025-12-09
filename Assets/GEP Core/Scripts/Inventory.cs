using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine.EventSystems;

public class Inventory : SortingInventory //MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gameManager;
    public GameObject sorting_inventory_script;

    [SerializeField]
    //List of items that have been collected in the inventory
    private List<string> items = new List<string>();
    //List of items that are avalible in the overworld.
    private List<GameObject> game_objects_list = new List<GameObject>();
    private int drops_in_one_go = 3;
    private int[,] dropoff_location = new int[9,2] { 
        {0,0 },{ 1, 0 },{ 0, 1}, 
        { 1,1 }, { -1, 0 }, { 0, -1 }, 
        { -1, -1 }, { 2, 1 }, { 1, 2 } };

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void addItem(string item_name)
    {
        items.Add(item_name);
    }

    public void removeItem(string item_name)
    {
        Debug.Log(gameManager.get_dropped_no());
        //if(drops_in_one_go > gameManager.get_dropped_no()) { 
        //Gets Item location in the list
        int item_location = getItemLocation(item_name);
        //SET GAMEOBJECT LOCATION IN FRONT OF PLAYER
        relocateItem(game_objects_list[item_location]);
        //Sets the in-game equivilant to active and removes from gameObejctList
        game_objects_list[item_location].gameObject.SetActive(true);
        // Removes object as collected
        game_objects_list.Remove(game_objects_list[item_location]);
        //Adjust count attached to button to corrolate to the amound of items in the inventory list
        int amount = getAmountOfItems(item_name); //Gets the amount of that item in the inventory list
        //Removes item from inventory list
        items.Remove(item_name);
        //resorts buttons and deactivates the one clicked.
        Debug.Log(items + " " + item_name + " REMOVING ITEM");
        sorting_inventory_script.GetComponent<SortingInventory>().activate_buttons(items);
        //}
        //activate_buttons(items);
        //Debug.Log(buttons_list.Count + "After Remove item");
        //Debug.Log(panel_list.Count);
    }

    public void relocateItem(GameObject item)
    {
        Vector3 currentPos = transform.position;
        Vector3 forward = transform.forward;

        //Debug.Log("POS: " + currentPos);
        //Debug.Log("FORWARD: " + forward);

        //Vector3 newPos = currentPos + (forward * 2);
        //newPos += new Vector3(dropoff_location[gameManager.get_dropped_no(),0], 1, dropoff_location[gameManager.get_dropped_no(),1]);

        Vector3 newPos = currentPos + new Vector3(dropoff_location[gameManager.get_dropped_no(), 0], 1, dropoff_location[gameManager.get_dropped_no(), 1]); ;
        newPos += (forward * 3);



        //Debug.Log("NewPOS: " + newPos);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);

        //item.transform.rotation = currentRotation;
        item.transform.position = newPos;
        gameManager.increase_dropped_no();
    }

    public List<string> getList() { return items; }

    private int getItemLocation(string name) 
    {
        if (items.Count != 0)
        {
            for(int i = 0; i < items.Count; i++) 
            {
                if (items[i] == name) 
                {
                    return i;
                }
            }
            return -1;
        }
        else 
        {
            return -1;
        }
 
    }

    private int getAmountOfItems(string name) 
    {
        int item_count = 0;
        if (items.Count != 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == name)
                {
                    item_count++;
                }
            }
            return item_count;
        }
        else
        {
            //If no items in the list
            return 0;
        }
    }


    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //If the player collides with an active object with the tag collectable.
        if (hit.transform.CompareTag("Collectable") && hit.gameObject.activeSelf == true) 
        {
            game_objects_list.Add(hit.gameObject);
            items.Add(hit.gameObject.name);
            hit.gameObject.SetActive(false);
            //Destroy(hit.gameObject);
        }
    }

}
