using UnityEngine;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
    [SerializeField] protected int numberItem;
    [SerializeField] protected Button _buyBtn;
    [SerializeField] protected int price;
    [SerializeField] protected Text _priceText;

    public StoreHandler.ItemType itemType;

    protected void Awake()
    {
        StartSet();

        _buyBtn.onClick.AddListener(() =>
        {
            TapButton();
        });
    }

    public virtual void StartSet()
    {
        _priceText.text = price.ToString();
    }

    protected virtual void TapButton()
    {
        if (BalanceUser.Instance.Balance >= price)
        {
            BalanceUser.Instance.DiscreaseBalance(price);
            StoreHandler.I.BuySuccessItem(numberItem, itemType);
        }
    }
}
