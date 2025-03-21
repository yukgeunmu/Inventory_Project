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
        backButton.onClick.AddListener(UIManager.Instace.UIMainMenu.OpenMainMenu);

        InitInventroyUI();
    }


    private void InitInventroyUI()
    {
        slotText.text = $"{currentSlot} / {totalSlot}";

        for(int i = 0; i < totalSlot; i++)
        {
            itemSlotList.Add(itemSlot);
            Instantiate(itemSlotList[i], slotPanel.transform);
        }
    }
}
