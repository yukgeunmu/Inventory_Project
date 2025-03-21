using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI currentExpText;
    public TextMeshProUGUI totalExpText;
    public TextMeshProUGUI goldText;
    public Slider expGage;

    public Button statusButton;
    public Button inventoryButton;


    private void Start()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }


    public void OpenMainMenu()
    {
        UIManager.Instace.UIStatus.gameObject.SetActive(false);
        UIManager.Instace.UIInventory.gameObject.SetActive(false);

    }
    
    public void OpenStatus()
    {
        UIManager.Instace.UIStatus.gameObject.SetActive(true);
    }

    public void OpenInventory()
    {
        UIManager.Instace.UIInventory.gameObject.SetActive(true);
    }

}
