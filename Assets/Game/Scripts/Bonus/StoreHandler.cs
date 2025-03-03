using UnityEngine;
using UnityEngine.UI;

public class StoreHandler : ScreenPanel
{
    public static StoreHandler I;

    private WrapperDataBonus wrapperDataBonus;

    [SerializeField] private Text _countBonus1;
    [SerializeField] private Text _countBonus2;
    [SerializeField] private Text _countBonus3;

    [SerializeField] private Button _openBtn;
    [SerializeField] private Button _closeBtn;

    [Header("Panels")]
    [SerializeField] private GameObject _bonusPanel;
    [SerializeField] private GameObject _bgPanel;

    [Header("Toolbar")]
    [SerializeField] private Button _bonusPanelButton;
    [SerializeField] private Button _bgPanelButton;
    [SerializeField] private Color _choiceColor;

    public enum ItemType
    {
        Bonus,
        Background
    }

    private void Awake()
    {
        if ( I == null)
        {
            I = this;
        }

        _bonusPanelButton.onClick.AddListener(() =>
        {
            _bonusPanel.SetActive(true);
            _bgPanel.SetActive(false);

            _bonusPanelButton.GetComponent<Image>().color = _choiceColor;
            _bgPanelButton.GetComponent<Image>().color = Color.white;
        });

        _bgPanelButton.onClick.AddListener(() =>
        {
            _bonusPanel.SetActive(false);
            _bgPanel.SetActive(true);

            _bgPanelButton.GetComponent<Image>().color = _choiceColor;
            _bonusPanelButton.GetComponent<Image>().color = Color.white;
        });

        _openBtn.onClick.AddListener(() =>
        {
            ScreensViewHandler.UI.OpenPanel(ScreensViewHandler.NamePanel.Store);
            UpdateDataBonus();
        });

        _closeBtn.onClick.AddListener(() =>
        {
            ScreensViewHandler.UI.OpenPanel(ScreensViewHandler.NamePanel.Menu);
        });
    }

    public void InitStore(WrapperDataBonus wrapperData)
    {
        wrapperDataBonus = wrapperData;
        UpdateDataBonus();
    }

    public void BuySuccessItem(int numBonus, ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Bonus:
                wrapperDataBonus.bonusDatas[numBonus].countBonus++;
                wrapperDataBonus.SaveData();
                UpdateDataBonus();
                break;
            case ItemType.Background:
                break;
        }
    }

    private void UpdateDataBonus()
    {
        _countBonus1.text = wrapperDataBonus.bonusDatas[0].countBonus.ToString();
        _countBonus2.text = wrapperDataBonus.bonusDatas[1].countBonus.ToString();
        _countBonus3.text = wrapperDataBonus.bonusDatas[2].countBonus.ToString();
    }
}
