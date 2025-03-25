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

---------------------------------------------------------------------------------------------------------------------------

## STEP4. 캐릭터 벙보 세팅하기

## STEP5. UISlot 동적생성하기
## STEP6. Item 데이터 준비하기
## STEP7. 아이템 장착
## STEP8. Status에 아이템 정보 반영
