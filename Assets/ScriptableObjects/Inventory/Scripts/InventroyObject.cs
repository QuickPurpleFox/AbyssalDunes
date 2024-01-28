using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventroyObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();

    public void AddItem(ItemObject item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == item)
            {
                hasItem = true;
                container.Add(new InventorySlot(item, amount));
                break;
            }
        }
        if (!hasItem)
        {
            container.Add(new InventorySlot(item, amount));
        }
    }
}
