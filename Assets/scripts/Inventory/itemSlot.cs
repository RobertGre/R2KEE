using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System;

public class ItemSlot : MonoBehaviour
{

    //-------------------ITEM DATA--------------------//

    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
  


    //---------------------ITEM SLOT------------------//

    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

   

    
    
    private InventoryManager inventoryManager;   //enables this script to talk to inventory manager

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;   //tells script item name is sent in from inv manager 
        this.quantity = quantity;       // quantity sent from inv mangr
        this.itemSprite = itemSprite;        //  sprite from inv mngr
       
        isFull = true;                   // bool = true since theres item in inv 


        quantityText.text = quantity.ToString();     //quantity => string, for quantity text
        quantityText.enabled = true;                // ticks text checkbox showing text
        itemImage.sprite = itemSprite;

    }

  


}
