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
    public JobType jobType { get; private set; }
    public string characterName { get; private set; }
    public int level { get; private set; }
    public float exp { get; private set; }
    public float maxExp { get; private set; }
    public float attackdamage { get; private set; }
    public float defence { get; private set; }
    public float health { get; private set; }
    public float critical { get; private set; }
    public int gold { get; private set; }

    public List<Item> inventroy { get; private set; }

    public Character(JobType job, string _characterName, int _level, float _exp, float _maxExp, float _attackdamage, float _defence, float _health, float _critical, int _gold, List<Item> _inventroy)
    {
        jobType = job;
        characterName = _characterName;
        level = _level;
        exp = _exp;
        maxExp = _maxExp;
        attackdamage = _attackdamage;
        defence = _defence;
        health = _health;
        critical = _critical;
        gold = _gold;
        this.inventroy = _inventroy;
    }


    public void Additem(List<Item> items)
    {

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

}
