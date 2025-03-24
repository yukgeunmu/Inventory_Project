using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public UIManager uIManager;
    public Sprite[] sprite;

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

    private void Start()
    {
        SetData();
    }

    public void ItemData()
    {

    }

    public void SetData()
    {
        ItemDataStatus[] swordStatus = new ItemDataStatus[]
        {
            new ItemDataStatus{type = StatusType.AttackDamge, value = 5f },
            new ItemDataStatus{type = StatusType.Critical, value = 2f }
        };

        ItemDataStatus[] staffStatus = new ItemDataStatus[]
{
            new ItemDataStatus{type = StatusType.AttackDamge, value = 1f },
            new ItemDataStatus{type = StatusType.Critical, value = 10f }
};

        ItemDataStatus[] HpPotion = new ItemDataStatus[]
        {
            new ItemDataStatus{type = StatusType.Health, value =50 }
        };

        List<Item> startInventory = new List<Item>() {

            new Item("Health Potion", "HP 50", ItemType.Consumalbe, sprite[0], true, 100, HpPotion),
            new Item("Health Potion", "HP 50", ItemType.Consumalbe, sprite[0], true, 100, HpPotion),
            new Item("Health Potion", "HP 50", ItemType.Consumalbe, sprite[0], true, 100, HpPotion),
            new Item("Iron Sword", "Weapon", ItemType.Equipable, sprite[1], false, 1, swordStatus),
             new Item("Wiar Staff", "Staff", ItemType.Equipable, sprite[2], false, 1, staffStatus)

        };


        Player = new Character(JobType.Warrior, "Spartan Warrior", 1, 1f, 10f, 10f, 10f, 100f, 10f, 100,startInventory);

        UIManager.Instance.UIMainMenu.SetJobType(Player.jobType);
        UIManager.Instance.UIMainMenu.SetName(Player.characterName);
        UIManager.Instance.UIMainMenu.SetLevel(Player.level);
        UIManager.Instance.UIMainMenu.SetExp(Player.exp, Player.maxExp);
        UIManager.Instance.UIMainMenu.SetGold(Player.gold);
        UIManager.Instance.UIStatus.SetAttackDamage(Player.attackdamage);
        UIManager.Instance.UIStatus.SetDefence(Player.defence);
        UIManager.Instance.UIStatus.SetHealth(Player.health);
        UIManager.Instance.UIStatus.SetCritical(Player.critical);


        UIManager.Instance.UIInventory.InitInventroyUI();

        foreach(var item in Player.inventroy)
        {
            foreach(var slot in uIManager.UIInventory.itemSlotList)
            {
                if(slot.item == null)
                {
                    slot.SetItem(item);
                    break;
                }

                if (slot.itemName == item.itemName)
                {
                    if (item.canStack)
                    {
                        slot.quantity++;
                        slot.quantityText.text = slot.quantity.ToString();
                        break;
                    }
                    else break;
                }
            }

        }

    }

}
