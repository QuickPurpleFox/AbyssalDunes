using System;
using UnityEngine;

public enum ItemType
{
    Potion,
    Jewelry
}
public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(5,10)] 
    public String description;
}

