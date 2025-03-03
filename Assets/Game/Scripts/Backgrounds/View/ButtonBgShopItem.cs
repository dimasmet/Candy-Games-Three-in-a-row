using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBgShopItem : ItemShop
{
    [SerializeField] private Text _stateText;

    private ItemBgShop itemData;

    protected override void TapButton()
    {
        BgsHandler.Instance.ChoiceItem(numberItem);
    }

    public override void StartSet()
    {

    }

    public void InitiButton(WrapperDataBackgrounds wrapperDataBackgrounds)
    {
        itemData = wrapperDataBackgrounds.itemBgShops[numberItem];
        price = itemData.price;
        _priceText.text = itemData.price.ToString();
        StateChange(itemData.stateItemShop);
    }

    public void StateChange(StateItemShop stateItemShop)
    {
        switch (stateItemShop)
        {
            case StateItemShop.NoBuy:
                _stateText.text = "BUY";
                break;
            case StateItemShop.Buyed:
                _stateText.text = "SELECT";
                break;
            case StateItemShop.Active:
                _stateText.text = "ACTIVE";
                break;
        }
    }
}
