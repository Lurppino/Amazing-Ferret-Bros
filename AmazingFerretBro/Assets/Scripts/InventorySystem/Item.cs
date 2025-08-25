using JetBrains.Annotations;
using UnityEngine;
public enum ItemType {Instant, Storable, Passive}

[CreateAssetMenu(fileName = "New Item", menuName = "InventorySystem/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType type;
}