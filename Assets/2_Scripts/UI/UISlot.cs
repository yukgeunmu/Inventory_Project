using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Item item;

    [Header("Info")]
    public string itemName = null;
    public string description = null;
    public ItemType itemType;

    [Header("Stacking")]
    public bool canStack;
    public int MaxStackAmount;

    [Header("StatusType")]
    public ItemDataStatus[] statusType;

    public UIInventory inventory;
    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;

    public int index;
    public bool equipped;
    public TextMeshProUGUI equipText;
    public int quantity;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        inventory = GetComponentInParent<UIInventory>();
    }

    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    public void SetItem(Item addItem)
    {
        item = addItem;
        itemName = item.itemName;
        description = item.description;
        itemType = item.itemType;
        canStack = item.canStack;
        MaxStackAmount = item.MaxStackAmount;
        statusType = item.statusType;
        icon.sprite = addItem.icon;
        quantity = 1;

        quantityText.text = quantity >= 1 ? quantity.ToString() : "0";

        if (outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void RefreshUI()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;

    }

    public void OnEquip()
    {
        if(itemType == ItemType.Equipable)
        {
            if (!equipped)
            {
                equipText.gameObject.SetActive(true);
                equipped = true;
                GameManager.Instance.Player.Equip(item);

            }
            else
            {
                equipText.gameObject.SetActive(false);
                equipped = false;
                GameManager.Instance.Player.UnEquip(item);
            }
        }
    }


}
