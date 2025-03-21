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
    public JobType jobType;
    public string characterName;
    public int level;
    public float exp;
    public float attackdamage;
    public float defence;
    public float health;
    public float critical;
    public int gold;

    public Character(JobType job, string _characterName, int _level, float _exp, float _attackdamage, float _defence, float _health, float _critical, int _gold)
    {
        jobType = job;
        characterName = _characterName;
        level = _level;
        exp = _exp;
        attackdamage = _attackdamage;
        defence = _defence;
        health = _health;
        critical = _critical;
        gold = _gold;
    }



}
