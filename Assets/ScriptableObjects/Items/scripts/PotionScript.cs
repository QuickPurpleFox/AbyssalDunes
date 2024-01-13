using UnityEngine;

[CreateAssetMenu(fileName = "New Potion Object", menuName = "Inventory System/items/potion")]
public class PotionScript : ItemObject
{
    public int restoreHealthValue;
    private void Awake()
    {
        type = ItemType.Potion;
    }
}
