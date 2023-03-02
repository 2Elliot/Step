using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake() {
        BuildDataBase();
    }

    public Item GetItem(int id) {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName) {
        return items.Find(item => item.title == itemName);
    }

    void BuildDataBase() {
        items = new List<Item>() {
            new Item(0, "Torch", "A glowing piece of wood", 
            new Dictionary<string, int>{
                { "Value", 5 },
                { "Durability", 15 }
            }),

            new Item(1, "Flashlight", "A metal rod with a small lightbulb in the end", 
            new Dictionary<string, int>{
                { "Value", 25 },
                { "Durability", 50}
            }),

            new Item(2, "Thing", "Test item", 
            new Dictionary<string, int>{
                { "Power", 5 },
                { "Defence", 0 }
            })
        };
    }
}
