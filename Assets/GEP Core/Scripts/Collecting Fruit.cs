using System;
using UnityEngine;
using System.Collections;

public class CollectingFruit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            
        }   
    }

    private void OnMouseOver()
    {
        Console.WriteLine(gameObject.name);
    }
}
