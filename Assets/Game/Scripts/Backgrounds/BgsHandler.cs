using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WrapperDataBackgrounds
{
    public ItemBgShop[] itemBgShops;

    public void SaveData()
    {
        string strJson = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("BackgroundsData", strJson);
    }

    public WrapperDataBackgrounds GetData()
    {
        string strJson = PlayerPrefs.GetString("BackgroundsData");

        WrapperDataBackgrounds dataBackground = this;

        if (strJson != "")
            dataBackground = JsonUtility.FromJson<WrapperDataBackgrounds>(strJson);

        return dataBackground;
    }
}

public class BgsHandler : MonoBehaviour
{
    public static BgsHandler Instance;

    [SerializeField] private WrapperDataBackgrounds wrapperDataBackgrounds;
    [SerializeField] private ButtonBgShopItem[] buttonBgShopItems;

    [SerializeField] private Sprite[] _backgroundsSprites;
    [SerializeField] private Sprite[] _backgroundSmallSprites;

    [SerializeField] private SpriteRenderer bgRender;
    [Header("View")]
    [SerializeField] private Image _imgCurrentBg;
    [SerializeField] private Image _backStore;

    private int currentActive = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        wrapperDataBackgrounds = wrapperDataBackgrounds.GetData();

        for (int i = 0; i < buttonBgShopItems.Length; i++)
        {
            buttonBgShopItems[i].InitiButton(wrapperDataBackgrounds);

            if (wrapperDataBackgrounds.itemBgShops[i].stateItemShop == StateItemShop.Active)
                currentActive = i;
        }

        _imgCurrentBg.sprite = _backgroundSmallSprites[currentActive];
        bgRender.sprite = _backgroundsSprites[currentActive];
        _backStore.sprite = _backgroundsSprites[currentActive]; 
    }

    public void ChoiceItem(int number)
    {
        if (currentActive == number) return;

        ItemBgShop itemNew = wrapperDataBackgrounds.itemBgShops[number];

        if (itemNew.stateItemShop == StateItemShop.NoBuy)
        {
            if (BalanceUser.Instance.Balance >= itemNew.price)
            {
                BalanceUser.Instance.DiscreaseBalance(itemNew.price);

                SwitchItemsActive(number);
            }
        }
        else
        {
            if (itemNew.stateItemShop == StateItemShop.Buyed)
            {
                SwitchItemsActive(number);
            }
        }
    }

    private void SwitchItemsActive(int numberNew)
    {
        wrapperDataBackgrounds.itemBgShops[numberNew].stateItemShop = StateItemShop.Active;
        buttonBgShopItems[numberNew].StateChange(StateItemShop.Active);
        wrapperDataBackgrounds.itemBgShops[currentActive].stateItemShop = StateItemShop.Buyed;
        buttonBgShopItems[currentActive].StateChange(StateItemShop.Buyed);

        wrapperDataBackgrounds.SaveData();

        currentActive = numberNew;

        _imgCurrentBg.sprite = _backgroundSmallSprites[currentActive];
        bgRender.sprite = _backgroundsSprites[currentActive];
        _backStore.sprite = _backgroundsSprites[currentActive];
    }
}