using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public UISlot itemSlot;
    public List<UISlot> itemSlotList;
    public Transform slotPanel;
    public TextMeshProUGUI slotText;

    public int currentSlot;
    public int totalSlot;
    public Button backButton;

    //[Header("Selected Item")]
    //private ItemSlot selectedItem;
    //private int selectedItemIndex;
    //public TextMeshProUGUI selectedItemName;
    //public TextMeshProUGUI selectedDescription;
    //public TextMeshProUGUI selectedStatName;
    //public TextMeshProUGUI selectedStatValue;


    private void Start()
    {
        backButton.onClick.AddListener(UIManager.Instance.UIMainMenu.OpenMainMenu);
    }


    public void InitInventroyUI()
    {
        slotText.text = $"{currentSlot} / {totalSlot}";

        itemSlotList.Clear();

        for(int i = 0; i < totalSlot; i++)
        {
            UISlot newSlot =  Instantiate(itemSlot, slotPanel.transform);
            newSlot.index = i;
            itemSlotList.Add(newSlot);
        }
    }

    public void SetInventory(List<Item> items)
    {
        foreach(var addItem in items)
        {
            foreach(var slot in itemSlotList)
            {
                if(slot.item == null)
                {
                    slot.SetItem(addItem);
                    break;
                }
                else
                {
                    if(slot.item.itemName == addItem.itemName && addItem.canStack)
                    {
                        slot.SetItem(addItem);
                        break;
                    }                  
                }
            }
        }

    }
}
