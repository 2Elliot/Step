using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDataBase;
    public UIInventory inventoryUI;

    private void Start() {
        GiveItem(1);
        GiveItem(2);
        GiveItem(0);
        RemoveItem(1);
        RemoveItem(1);
    }

    public void GiveItem(int id) {
        Item itemToAdd = itemDataBase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added Item: " + itemToAdd.title);
    }

    public void GiveItem(string itemName) {
        Item itemToAdd = itemDataBase.GetItem(name);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added Item: " + itemToAdd.title);
    }

    public Item CheckForItem(int id) {
        return characterItems.Find(item => item.id == id);
    }

    public Item CheckForItem(string itemName) {
        return characterItems.Find(item => item.title == itemName);
    }

    public void RemoveItem(int id) {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null) {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Item Removed: " + itemToRemove.title);
        } else {
            Debug.LogError("Item " + id + " is not in inventorys");
        }
    }

        public void RemoveItem(string itemName) {
        Item itemToRemove = CheckForItem(itemName);
        if (itemToRemove != null) {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Item Removed: " + itemToRemove.title);
        } else {
            Debug.LogError("Item " + itemName + " is not in inventorys");
        }
    }
}
