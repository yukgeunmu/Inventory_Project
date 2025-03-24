using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public UIManager uIManager;
    public Character player;

    public static GameManager Instance
    {
        get 
        {
            if(instance == null)
            {
                   instance = new GameObject("GameManager").AddComponent<GameManager>(); 
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }

    private void Start()
    {
        uIManager.UIInventory.InitInventroyUI();
        SetData();
    }

    public void SetData()
    {
        UIManager.Instance.UIMainMenu.SetJobType(player.jobType);
        UIManager.Instance.UIMainMenu.SetName(player.characterName);
        UIManager.Instance.UIMainMenu.SetLevel(player.level);
        UIManager.Instance.UIMainMenu.SetExp(player.exp, player.maxExp);
        UIManager.Instance.UIMainMenu.SetGold(player.gold);
        UIManager.Instance.UIStatus.SetAttackDamage(player.attackdamage);
        UIManager.Instance.UIStatus.SetDefence(player.defence);
        UIManager.Instance.UIStatus.SetHealth(player.health);
        UIManager.Instance.UIStatus.SetCritical(player.critical);
        UIManager.Instance.UIInventory.SetInventory(player.inventroy);

    }

}
