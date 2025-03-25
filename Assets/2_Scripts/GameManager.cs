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
        UIManager.Instance.UpdateUI(player);

    }

}
