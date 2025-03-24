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
                    Debug.Log("���������ۿ� ���� �ʴ� ��ġ�� �ԷµǾ����ϴ�.");
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
                    Debug.Log("���������ۿ� ���� �ʴ� ��ġ�� �ԷµǾ����ϴ�.");
                    break;
            }
        }
    }

}
