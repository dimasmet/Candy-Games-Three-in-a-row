using UnityEngine;
using UnityEngine.UI;

public class BalanceUser : MonoBehaviour
{
    public static BalanceUser Instance;

    [SerializeField] private Text[] _balanceText;
    private int balanceInt;

    public int Balance
    {
        get
        {
            return balanceInt;
        }
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        balanceInt = PlayerPrefs.GetInt("Balance");

        if (balanceInt == 0)
            balanceInt = 500;
#if UNITY_EDITOR
        balanceInt = 2500;
#endif
        UpdateTextField();
    }

    private void UpdateTextField()
    {
        for (int i = 0; i < _balanceText.Length; i++)
        {
            _balanceText[i].text = balanceInt.ToString();
        }
        PlayerPrefs.SetInt("Balance", balanceInt);
    }

    public void AddCoinBalance(int value)
    {
        balanceInt += value;
        UpdateTextField();
    }

    public void DiscreaseBalance(int value)
    {
        balanceInt -= value;
        UpdateTextField();
    }

}
