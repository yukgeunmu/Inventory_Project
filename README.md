# 인벤토리 구현하기
## STEP1. UI 구성하기
![image](https://github.com/user-attachments/assets/6df417af-85d8-4fb0-9569-6ed31e4ed0b2)

- 위 그림과 같이 UI를 구성했습니다.
- 둥근 모서리를 가진 사각형은 Circle 이미지를 Image Type을 Sliced로 바꾸어서 크기만 바꾸는 식으로 재활용했습니다.

---------------------------------------------------------------------------------------------------------------------------
## STEP2. 스크립트 만들기

```
2_Scripts
┣ UI
┃ ┣ ItemTooltip.cs
┃ ┣ UIInventory.cs
┃ ┣ UIMainMenu.cs
┃ ┣ UIManager.cs
┃ ┣ UISlot.cs
┃ ┣ UIStatus.cs
┣ Character.cs
┣ GameManager.cs
┗ UI.meta
```
- 위와 같이 Scripts 폴더 안에 스크립트를 작성했습니다.

```C#
public class UIManager : MonoBehaviour
{
[SerializeField] private UIMainMenu uIMainMenu;
public UIMainMenu UIMainMenu => uIMainMenu;

[SerializeField] private UIStatus uIStatus;
public UIStatus UIStatus => uIStatus;

[SerializeField] private UIInventory uIInventory;
public UIInventory UIInventory => uIInventory;
}
```
- 그리고 UIManager 스크립트에 [SerializedField]를 활용하여 3개의 UI를 연결 시켰습니다.
```C#
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
}
```
- Character 클래스에 위와 같이 변수를 선언해주었습니다.

---------------------------------------------------------------------------------------------------------------------------
## STEP3. UI간 전환 기능 만들기
```C#
public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
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
```
- 위와 같이 UIManager를 싱클톤 패턴을 만들어주었습니다.
```C#
public class UIMainMenu : MonoBehaviour
{
    public Button statusButton;
    public Button inventoryButton;

    private void Start()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }

    public void OpenMainMenu()
    {
        UIManager.Instance.UIStatus.gameObject.SetActive(false);
        UIManager.Instance.UIInventory.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        UIManager.Instance.UIStatus.gameObject.SetActive(true);
    }

    public void OpenInventory()
    {
        UIManager.Instance.UIInventory.gameObject.SetActive(true);
    }


}
```
- UIMainMenu에서 Status UI와 Inventory UI가 전환 될 수 있도록 코드를 작성해주었습니다.

-------------------------------------------------------------------------------------------------
## STEP4. 캐릭터 정보 세팅하기
```C#
public class GameManager : MonoBehaviour
{
     public void SetData()
    {
        UIManager.Instance.UpdateUI(player);
    }
}
```
- GameManager에서 player를 정보를 받아와 UIManager에서 UpdataUI를 호출해서 UI를 업데이트 해주는 SetData 매서드를 위와 같이 작숭해주었습니다.
```C#
public class UIManager : MonoBehaviour
{
    public void UpdateUI(Character player)
    {
        uIMainMenu.UpdateMainMenu(player);
        uIStatus.UpdateStatus(player);
        uIInventory.SetInventory(player.inventroy);
    }
}
```
- 그리고 UIManager에서 플레이어 관련 정보를 UI에서 업데이트 할 수 있도록 구현하였습니다.

  -------------------------------------------------------------------------------------------------
## STEP5. UISlot 동적생성하기
![image](https://github.com/user-attachments/assets/88e493ae-996b-4e5c-9a1c-e0e59316b8f0)

- 유니티에 Scroll View 기능과 Layout Group 컴포넌트를 활용해 UISlot이 동적으로 갯수가 늘어나도 인벤토리 칸 안에 들어 갈 수 있도록 구현했습니다.

```C#
public class UIInventory : MonoBehaviour
{
    public void InitInventroyUI()
    {
        slotText.text = $"{currentSlot} / {totalSlot}";

        itemSlotList.Clear();

        for(int i = 0; i < totalSlot; i++)
        {
            UISlot newSlot =  Instantiate(itemSlot, slotPanel.transform);
            newSlot.index = i;
            itemSlotList.Add(newSlot);
        }
    }

}
```
- 위와 같이 UIInventory에서 인벤토리에 UISlot을 초기화 시켜주는 InitInventoryUI 매서드를 작성해주었습니다.

  -------------------------------------------------------------------------------------------------
## STEP6. Item 데이터 준비하기
```C#
public enum ItemType
{
    Resource,
    Equipable,
    Consumalbe
}

public enum StatusType
{
    AttackDamge,
    Defence,
    Critical,
    Health,
    Exp
}

[System.Serializable]
public class ItemDataStatus
{
    public StatusType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "Item/ItemData")]
public class Item : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType itemType;
    public Sprite icon;

    [Header("Stacking")]
    public bool canStack;
    public int MaxStackAmount;

    [Header("StatusType")]
    public ItemDataStatus[] statusType;
}

```
- 위와 같이 Item 스크립트를 ScriptableObject로 만들어 데이터 관리를 쉽게 할 수 있도록 구현했습니다.

  -------------------------------------------------------------------------------------------------
## STEP7. 아이템 장착
```C#
public class UISlot : MonoBehaviour
{
    public void OnEquip()
    {
        if (item == null) return;

        if (item.itemType ==  ItemType.Equipable)
        {
            if (GameManager.Instance.player.equipItem == null)
            {
                SelfEquip();
            }
            else if (GameManager.Instance.player.equipItem.index != index)
            {
                GameManager.Instance.player.equipItem.outline.enabled = false;
                GameManager.Instance.player.equipItem.equipText.SetActive(false);
                GameManager.Instance.player.UnEquip(GameManager.Instance.player.equipItem.item);

                SelfEquip();

            }
            else
            {
                outline.enabled = false;
                equipText.gameObject.SetActive(false);
                GameManager.Instance.player.equipItem = null;
                GameManager.Instance.player.UnEquip(item);
            }          
        }
    }

}
```
- 위와 같이 UISlot 스크립트에서 아이템 슬롯을 클릭 시 장착 아이템이 장착되는 OnEquip 매서드를 구현했습니다.
- 장착이 안된 아이템을 누르면 장착이 되고 장착 된 아이템을 한번 더 누르면 장착이 해제하도록 구현했습니다.
- 그리고 장착 아이템을 하나만 장착 할 수 있도록 구현하였습니다.

  -------------------------------------------------------------------------------------------------
## STEP8. Status에 아이템 정보 반영
```C#
public class Character : MonoBehaviour
{
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
```

- Character 스크립트에서 장착이 되면 Status에 반영 하는 Equip 매서드를 작성해주었습니다.
- 장착이 해제되면 UnEquip 매서드를 호출해 Status가 이전 값으로 돌아가도록 구현하였습니다.

