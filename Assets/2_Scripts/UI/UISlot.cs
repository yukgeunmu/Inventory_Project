using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Item item;
    public UIInventory inventory;
    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    public Outline outline;

    public int index;
    public bool equipped;
    public TextMeshProUGUI equipText;
    public int quantity;

    private void Awake()
    {
        inventory = GetComponentInParent<UIInventory>();
    }


    public void SetItem(Item addItem)
    {
        if (item != null)
        {
            if (item.itemName == addItem.itemName)
            {
                quantity++;
            }
        }
        else
        {
            item = addItem;
            icon.sprite = addItem.icon;
            quantity = 1;
        }

        quantityText.text = quantity.ToString();
    }


    public void RefreshUI()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;

    }

    public void OnEquip()
    {
        if(item != null)
        {
            if (item.itemType == ItemType.Equipable)
            {
                equipped = !equipped;
                equipText.gameObject.SetActive(equipped);
                outline.enabled = equipped;

                GameManager.Instance.player.equipItem = item;
                if (equipped)  GameManager.Instance.player.Equip(item);
                else  GameManager.Instance.player.UnEquip(item);
            }

        }

    }
}
