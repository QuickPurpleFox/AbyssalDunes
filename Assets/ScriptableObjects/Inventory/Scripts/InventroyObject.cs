using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventroyObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();

    public void AddItem(ItemObject item, int amount)
    {
        container.Add(new InventorySlot(item, amount));
    }
}
