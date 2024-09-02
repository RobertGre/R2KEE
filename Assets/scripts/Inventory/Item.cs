using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;


    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddToInventory()
    {
        if(inventoryManager!= null)
        {
            inventoryManager.AddItem(itemName, quantity, sprite);   //universal function can be called into anything 
            gameObject.SetActive(false); // Deactivate the game object

        }
       
    }


   
}

