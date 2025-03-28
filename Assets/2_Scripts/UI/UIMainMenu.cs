using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI goldText;
    public Image expGage;

    public Button statusButton;
    public Button inventoryButton;


    private void Start()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }


    public void OpenMainMenu()
    {
        UIManager.Instance.UIStatus.gameObject.SetActive(false);
        UIManager.Instance.UIInventory.gameObject.SetActive(false);

    }

    public void SetJobType(JobType _jobType)
    {
        jobText.text = _jobType.ToString();
    }

    public void SetName(string _Name)
    {
        nameText.text = _Name;
    }

    public void SetLevel(int level)
    {
        levelText.text = $"Lv {level}";
    }

    public void SetExp(float currentExp, float maxExp)
    {
        expText.text = $"{currentExp} / {maxExp}";
        expGage.fillAmount = currentExp / maxExp;   
    }

    public void SetGold(int gold)
    {
        goldText.text = gold.ToString();
    }
    
    public void OpenStatus()
    {
        UIManager.Instance.UIStatus.gameObject.SetActive(true);
    }

    public void OpenInventory()
    {
        UIManager.Instance.UIInventory.gameObject.SetActive(true);
    }

    public void UpdateMainMenu(Character player)
    {
        SetJobType(player.jobType);
        SetName(player.characterName);
        SetLevel(player.level);
        SetExp(player.exp, player.maxExp);
        SetGold(player.gold);
    }

}
