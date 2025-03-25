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
       if(backButton != null)
        backButton.onClick.AddListener(UIManager.Instance.UIMainMenu.OpenMainMenu);
    }


    public void SetAttackDamage(float _attackDamage)
    {
        attackValueText.text = _attackDamage.ToString();
    }

    public void SetDefence(float _defenceValue)
    {
        defenceValueText.text = _defenceValue.ToString();
    }

    public void SetHealth(float _health)
    {
        healthValueText.text = _health.ToString();
    }

    public void SetCritical(float _criticalValue)
    {
        criticalValueText.text = _criticalValue.ToString();
    }

    public void UpdateStatus(Character player)
    {
        SetAttackDamage(player.attackdamage);
        SetDefence(player.defence);
        SetHealth(player.health);
        SetCritical(player.critical);
    }

}
