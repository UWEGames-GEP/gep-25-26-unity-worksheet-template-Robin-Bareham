using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;

public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gameManager;

    [SerializeField]
    private List<string> items = new List<string>();
    

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
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && gameManager.getState() == GameManager.GameState.GAMEPLAY) 
        {
            removeItem("Apple");
        }*/

    }

    public void addItem(string item_name)
    {
        items.Add(item_name);
        sortList();
    }

    public void removeItem(string item_name) 
    {
        items.Remove(item_name);
    }

    private void sortList() 
    {
        items.Sort();
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Collectable")) 
        {
            items.Add(hit.gameObject.name);
            Destroy(hit.gameObject);
        }
    }

}
