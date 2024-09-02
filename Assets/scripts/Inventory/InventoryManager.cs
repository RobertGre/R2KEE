using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public List<ItemSlot> itemSlots = new List<ItemSlot>();
    private bool menuActivated;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (menuActivated)
            {
                Time.timeScale = 1;
                InventoryMenu.SetActive(false); // Deactivates menu
                menuActivated = false;
            }
            else
            {
                Time.timeScale = 1; // Pauses the game
                InventoryMenu.SetActive(true); // Activates menu
                menuActivated = true;
            }
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        ItemSlot emptySlot = itemSlots.Find(slot => !slot.isFull);
        if (emptySlot != null)
        {
            emptySlot.AddItem(itemName, quantity, itemSprite);
        }
    }

    /*  public bool UseItem(string itemName, int quantity)
    {
        ItemSlot itemSlot = itemSlots.Find(slot => slot.itemName == itemName);
        if (itemSlot != null && itemSlot.quantity >= quantity)
        {
            itemSlot.quantity -= quantity;
            if (itemSlot.quantity <= 0)
            {
                itemSlots.Remove(itemSlot);
            }
            // Update UI or perform any other necessary actions
            return true;
        }
        return false;
    }

    // Method to deselect all item slots
    public void DeselectAllSlots()
    {
        foreach (ItemSlot slot in itemSlots)
        {
            slot.thisItemSelected = false;
            slot.selectedShader.SetActive(false);
        }
    }
    // Method to check if the player has a specific item */

    
}



