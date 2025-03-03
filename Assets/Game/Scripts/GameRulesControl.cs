using UnityEngine;
using UnityEngine.UI;

public class GameRulesControl : MonoBehaviour
{
    public static GameRulesControl I;

    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject[] _rulesPanels;
    private int number;

    [SerializeField] private Text _numberStepText;
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Button _backBtn;

    private GameObject _currentActive;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }

        _nextBtn.onClick.AddListener(() => {
            NextStepRules();
        });

        _backBtn.onClick.AddListener(() =>
        {
            BackStepRules();
        });
    }

    public void ShowRules(bool isUserInvoke)
    {
        number = 0;

        if (_currentActive != null) _currentActive.SetActive(false);

        _currentActive = _rulesPanels[number];
        _currentActive.SetActive(true);

        _mainPanel.SetActive(true);

        _numberStepText.text = (number +1) + "/3";

        _backBtn.gameObject.SetActive(false);
    }

    private void NextStepRules()
    {
        number++;

        if (number == 1)
            _backBtn.gameObject.SetActive(true);

        if (number < _rulesPanels.Length)
        {
            _numberStepText.text = (number + 1) + "/3";
            if (_currentActive != null) _currentActive.SetActive(false);

            _currentActive = _rulesPanels[number];
            _currentActive.SetActive(true);
        }
        else
        {
            _mainPanel.SetActive(false);
        }
    }

    private void BackStepRules()
    {
        number--;

        if (number >= 0)
        {
            _numberStepText.text = (number + 1) + "/3";
            if (_currentActive != null) _currentActive.SetActive(false);

            _currentActive = _rulesPanels[number];
            _currentActive.SetActive(true);

            if (number == 0)
            {
                _backBtn.gameObject.SetActive(false);
            }
        }
    }
}
