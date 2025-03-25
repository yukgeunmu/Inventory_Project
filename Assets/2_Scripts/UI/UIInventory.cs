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

    [Header("Itme Infomation")]
    public GameObject IteminfoWindow;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedDescription;
    public TextMeshProUGUI selectedStat;



    private void Start()
    {
        backButton.onClick.AddListener(UIManager.Instance.UIMainMenu.OpenMainMenu);
    }


    public void InitInventoryUI()
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
                    currentSlot += 1;
                    slotText.text = $"{currentSlot} / {totalSlot}";
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
