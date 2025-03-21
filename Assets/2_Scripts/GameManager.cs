using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public UIManager uIManager;

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

    private Character player;

    public Character Player
    {
        get { return player; }
        set { player = value; }
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

    public void SetData()
    {
        Player = new Character(JobType.Warrior, "유니티전사", 1, 1f, 10f, 10f, 10f, 100f, 10f, 100 );

        UIManager.Instace.UIMainMenu.SetJobType(Player.jobType);
        UIManager.Instace.UIMainMenu.SetName(Player.name);
        UIManager.Instace.UIMainMenu.SetLevel(Player.level);
        UIManager.Instace.UIMainMenu.SetExp(Player.exp, Player.maxExp);
        UIManager.Instace.UIMainMenu.SetGold(Player.gold);
        
    }

}
