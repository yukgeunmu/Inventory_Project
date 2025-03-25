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
    public GameObject equipText;
    public int quantity;

    private void Awake()
    {
        inventory = GetComponentInParent<UIInventory>(true);
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
        quantityText.text = "0";

    }

    public void OnEquip()
    {
        if (item == null) return;

        if (item.itemType ==  ItemType.Equipable)
        {
            SetEquipableType(ref GameManager.Instance.player.WeaponItem, EquipableType.WeaponItem);
            SetEquipableType(ref GameManager.Instance.player.AmorItem, EquipableType.AmorItem);
        }
        else if(item.itemType == ItemType.Consumalbe)
        {
            GameManager.Instance.player.Using(item);
            quantity--;

            if (quantity <= 0)
            {
                RefreshUI();
            }

            quantityText.text = quantity.ToString();
        }
    }

    public void SelfEquip(ref UISlot currentItemSlot)
    {
        outline.enabled = true;
        equipText.gameObject.SetActive(true);
        currentItemSlot = inventory.itemSlotList[index];
        GameManager.Instance.player.Equip(item);

    }

    public void SetEquipableType(ref UISlot currentItemSlot,EquipableType equipableType)
    {
        if (item.equipableType != equipableType) return;

        if (currentItemSlot == null)
        {
            SelfEquip(ref currentItemSlot);
        }
        else if (currentItemSlot.index != index)
        {
            currentItemSlot.outline.enabled = false;
            currentItemSlot.equipText.SetActive(false);
            GameManager.Instance.player.UnEquip(currentItemSlot.item);
            SelfEquip(ref currentItemSlot);
        }
        else
        {
            outline.enabled = false;
            equipText.gameObject.SetActive(false);
            currentItemSlot = null;
            GameManager.Instance.player.UnEquip(item);
        }
    }

}
