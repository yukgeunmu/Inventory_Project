using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instace
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("UIManager").AddComponent<UIManager>();
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    [SerializeField] private UIMainMenu uIMainMenu;
    public UIMainMenu UIMainMenu => uIMainMenu;

    [SerializeField] private UIStatus uIStatus;
    public UIStatus UIStatus => uIStatus;

    [SerializeField] private UIInventory uIInventory;
    public UIInventory UIInventory => uIInventory;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        uIMainMenu = GetComponentInChildren<UIMainMenu>();
        uIStatus = GetComponentInChildren<UIStatus>(true);
        uIInventory = GetComponentInChildren<UIInventory>(true);

        GameManager.Instance.uIManager = this;
    }

}
