using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resource,
    Equipable,
    Consumalbe
}

public enum StatusType
{
    AttackDamge,
    Defence,
    Critical,
    Health,

}


[System.Serializable]
public class ItemDataStatus
{
    public StatusType type;
    public float value;
}


public class Item
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType itemType;
    public Sprite icon;

    [Header("Stacking")]
    public bool canStack;
    public int MaxStackAmount;

    [Header("StatusType")]
    public ItemDataStatus[] statusType;



    public Item(string itemName, string description, ItemType itemType, Sprite icon, bool canStack, int maxStackAmount, ItemDataStatus[] statusType)
    {
        this.itemName = itemName;
        this.description = description;
        this.itemType = itemType;
        this.icon = icon;
        this.canStack = canStack;
        MaxStackAmount = maxStackAmount;
        this.statusType = statusType;
    }
}
