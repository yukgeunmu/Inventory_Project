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
    public GameObject equipText;
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
        if (item == null) return;

        if (inventory.equipItme.Contains(item))
        {
            if (GameManager.Instance.player.equipItem == null)
            {
                outline.enabled = true;
                equipText.gameObject.SetActive(true);
                GameManager.Instance.player.equipItem = inventory.itemSlotList[index];
                GameManager.Instance.player.Equip(item);
            }
            else if (GameManager.Instance.player.equipItem.index != index)
            {
                GameManager.Instance.player.equipItem.outline.enabled = false;
                GameManager.Instance.player.equipItem.equipText.SetActive(false);
                GameManager.Instance.player.UnEquip(GameManager.Instance.player.equipItem.item);

                outline.enabled = true;
                equipText.gameObject.SetActive(true);
                GameManager.Instance.player.equipItem = inventory.itemSlotList[index];
                GameManager.Instance.player.Equip(item);

            }
            else
            {
                outline.enabled = false;
                equipText.gameObject.SetActive(false);
                GameManager.Instance.player.equipItem = null;
                GameManager.Instance.player.UnEquip(item);
            }
            
        }
    }

}
