using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;

public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gameManager;
    public GameObject sorting_inventory_script;

    [SerializeField]
    private List<string> items = new List<string>();
    private List<GameObject> game_objects_list = new List<GameObject>();
    

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1) && gameManager.getState() == GameManager.GameState.GAMEPLAY)
        {
            addItem("Apple");
        }*/
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameManager.getState() == GameManager.GameState.INVENTORY) 
        {
            if(getItem() != "\0") 
            {
                string item_being_removed = getItem();
                removeItem(item_being_removed);
            }
            
        }

    }

    public void addItem(string item_name)
    {
        items.Add(item_name);
        //sortList();
    }

    public void removeItem(string item_name)
    {
        int item_location = getItemLocation(item_name);
        game_objects_list[item_location].gameObject.SetActive(true);
        game_objects_list.Remove(game_objects_list[item_location]);
        items.Remove(item_name);
        sorting_inventory_script.GetComponent<SortingInventory>().activate_buttons(items);
    }

    public string getItem()
    {
        if(items.Count != 0)
        {
            return items[0];
        }
        else
        {
            return "\0";
        }
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


    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Collectable") && hit.gameObject.activeSelf == true) 
        {
            game_objects_list.Add(hit.gameObject);
            items.Add(hit.gameObject.name);
            hit.gameObject.SetActive(false);
            //Destroy(hit.gameObject);
        }
    }

}
