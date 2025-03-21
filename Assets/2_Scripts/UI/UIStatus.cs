using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    public TextMeshProUGUI attackValueText;
    public TextMeshProUGUI defenceValueText;
    public TextMeshProUGUI healthValueText;
    public TextMeshProUGUI criticalValueText;

    public Button backButton;

    private void Start()
    {
       backButton.onClick.AddListener(UIManager.Instace.UIMainMenu.OpenMainMenu);
    }

}
