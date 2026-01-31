using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Search;
using UnityEngine.EventSystems;

public class Items : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gameManager;

    [SerializeField]
    //List of items that have been collected in the inventory
    private List<string> items = new List<string>();
    //List of items that are avalible in the overworld.
    private List<GameObject> game_objects_list = new List<GameObject>();
    private int drops_in_one_go = 3;
    private int[,] dropoff_location = new int[9, 2] {
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

    }

    //RESPAWNS ITEM INTO WORLD
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

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);

        item.transform.position = newPos;
        gameManager.increase_dropped_no();
    }

    public List<string> getItemList() {return items; }
    public List<GameObject> getGameObjectList() { return game_objects_list; }

    private int getItemLocation(string name)
    {
        if (items.Count != 0)
        {
            for (int i = 0; i < items.Count; i++)
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
}
