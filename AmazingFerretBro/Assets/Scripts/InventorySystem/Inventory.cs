using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    public void AddItem(Item newItem)
    {
        if(!inventory.Contains(newItem)) inventory.Add(newItem);
    }

    public void RemoveItem(Item oldItem)
    {
        if(inventory.Contains(oldItem)) inventory.Remove(oldItem);
    }

    public bool ContainsItem(Item item)
    {
        return inventory.Contains(item);
    }
}
