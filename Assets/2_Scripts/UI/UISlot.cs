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
        icon.sprite = addItem.icon;
        quantity = 1;
        quantityText.text = quantity.ToString();

        if (outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void SetStack(Item stackItem)
    {
        quantity++;
        quantityText.text = quantity > 1 ? quantity.ToString() : "0";
    }

    public void RefreshUI()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;

    }

    public void OnEquip()
    {
        if(item.itemType == ItemType.Equipable)
        {
            if (!equipped)
            {
                equipText.gameObject.SetActive(true);
                equipped = true;
                GameManager.Instance.player.Equip(item);

            }
            else
            {
                equipText.gameObject.SetActive(false);
                equipped = false;
                GameManager.Instance.player.UnEquip(item);
            }
        }
    }


}
