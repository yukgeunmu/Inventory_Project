using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIMainMenu uIMainMenu;
    [SerializeField] private UIStatus uIStatus;
    [SerializeField] private UIInventory uIInventory;

    private void Awake()
    {
        uIMainMenu = GetComponentInChildren<UIMainMenu>();
        uIStatus = GetComponentInChildren<UIStatus>(true);
        uIInventory = GetComponentInChildren<UIInventory>(true);
    }

}
