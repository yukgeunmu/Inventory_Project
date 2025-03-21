using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Character(JobType job, string _characterName, int _level, float _exp, float _maxExp, float _attackdamage, float _defence, float _health, float _critical, int _gold)
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
    }



}
