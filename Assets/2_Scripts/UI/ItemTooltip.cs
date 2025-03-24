using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class ItemTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UISlot slot;

    private void Awake()
    {
        slot = GetComponent<UISlot>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowItemInfo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CloseItemInfo();
    }


    public void ShowItemInfo()
    {
        if (slot.item == null) return;

        UIManager.Instance.UIInventory.IteminfoWindow.SetActive(true);
        UIManager.Instance.UIInventory.selectedItemName.text = slot.item.itemName;
        UIManager.Instance.UIInventory.selectedDescription.text = slot.item.description;

        foreach (var stat in slot.item.statusType)
        {
            UIManager.Instance.UIInventory.selectedStat.text += $"{stat.type} : {stat.value}\n";
        }
    }

    public void CloseItemInfo()
    {
        UIManager.Instance.UIInventory.IteminfoWindow.SetActive(false);
        UIManager.Instance.UIInventory.selectedItemName.text = "";
        UIManager.Instance.UIInventory.selectedDescription.text = "";
        UIManager.Instance.UIInventory.selectedStat.text = "";

    }

}
