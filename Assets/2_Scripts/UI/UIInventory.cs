using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] slots;
    public Transform slotPanel;

    public TextMeshProUGUI currentSlot;
    public TextMeshProUGUI totalSlot;
    public Button backButton;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedDescription;
    public TextMeshProUGUI selectedStatName;
    public TextMeshProUGUI selectedStatValue;

    private void Start()
    {
        backButton.onClick.AddListener(UIManager.Instace.UIMainMenu.OpenMainMenu);
    }
}
