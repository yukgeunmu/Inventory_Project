using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public enum JobType
{
    Warrior,
    Achor,
    Wizard
}

public class Character : MonoBehaviour
{
    public JobType jobType;
    public string characterName;
    public int level;
    public float exp;
    public float maxExp;
    public float attackdamage;
    public float defence;
    public float health;
    public float critical;
    public int gold;
    public UISlot equipItem;
    public List<Item> inventroy;

    private void Awake()
    {
        GameManager.Instance.player = this;
    }

    public void Equip(Item item)
    {

        for (int i = 0; i < item.statusType.Length; i++)
        {
            switch (item.statusType[i].type)
            {
                case StatusType.AttackDamge:
                    attackdamage += item.statusType[i].value;
                    UIManager.Instance.UIStatus.SetAttackDamage(attackdamage);
                    break;
                case StatusType.Defence:
                    defence += item.statusType[i].value;
                    UIManager.Instance.UIStatus.SetDefence(defence);
                    break;
                case StatusType.Critical:
                    critical += item.statusType[i].value;
                    UIManager.Instance.UIStatus.SetCritical(critical);
                    break;
                default:
                    Debug.Log("장착아이템에 맞지 않는 수치가 입력되었습니다.");
                    break;
            }
        }

    }

    public void UnEquip(Item item)
    {
        for (int i = 0; i < item.statusType.Length; i++)
        {
            switch (item.statusType[i].type)
            {
                case StatusType.AttackDamge:
                    attackdamage -= item.statusType[i].value;
                    UIManager.Instance.UIStatus.SetAttackDamage(attackdamage);
                    break;
                case StatusType.Defence:
                    defence -= item.statusType[i].value;
                    UIManager.Instance.UIStatus.SetDefence(defence);
                    break;
                case StatusType.Critical:
                    critical -= item.statusType[i].value;
                    UIManager.Instance.UIStatus.SetCritical(critical);
                    break;
                default:
                    Debug.Log("장착아이템에 맞지 않는 수치가 입력되었습니다.");
                    break;
            }
        }
    }

    public void Using(Item item)
    {
        for (int i = 0; i < item.statusType.Length; i++)
        {
            switch(item.statusType[i].type)
            {
                case StatusType.Health:
                    health += item.statusType[i].value;
                    health = Mathf.Clamp(health, 0f, 100f);
                    UIManager.Instance.UIStatus.SetHealth(health);
                    break;
                case StatusType.Exp:
                    exp += item.statusType[i].value;
                    UIManager.Instance.UIMainMenu.SetExp(exp,maxExp);
                    break;
            }
        }

    }

}
