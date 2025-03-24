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
    Exp

}


[System.Serializable]
public class ItemDataStatus
{
    public StatusType type;
    public float value;
}


[CreateAssetMenu(fileName = "Item", menuName = "Item/ItemData")]
public class Item : ScriptableObject
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
}
