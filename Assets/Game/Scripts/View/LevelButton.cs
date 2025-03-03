using UnityEngine;
using UnityEngine.UI;

public enum StateLevel
{
    Close,
    Open
}

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _lvlButton;

    [SerializeField] private Text _numberText;
    [SerializeField] private GameObject _closeIcon;
    [SerializeField] private Text _recordText;

    private LevelInfo levelInfo;

    private StateLevel currentState;

    private LevelsView _levelsView;

    private void Awake()
    {
        _lvlButton.onClick.AddListener(() =>
        {
            switch (currentState)
            {
                case StateLevel.Close:
                    _levelsView.ShowInfoForCloseLevel();
                    break;
                case StateLevel.Open:
                    Bootstrap.OnChoiceLevel?.Invoke(levelInfo.numberLvl);
                    Bootstrap.OnStartGame?.Invoke();
                    break;
            }
        });
    }

    public void ContructInit(LevelInfo level, LevelsView levelsView)
    {
        _levelsView = levelsView;
        levelInfo = level;
        ChangeStateLevelView(level.state);
        UpdateDataView();
    }

    public void UpdateDataView()
    {
        _numberText.text = (levelInfo.numberLvl + 1).ToString();
        if (levelInfo.timeRecord != 0)
        {
            _recordText.text = "BEST TIME: " + string.Format("{0:00}:{1:00}", Mathf.FloorToInt(levelInfo.timeRecord / 60), Mathf.FloorToInt(levelInfo.timeRecord % 60));
        }
        else
        {
            _recordText.text = "BEST TIME: " + "-";
        }
    }

    public void ChangeStateLevelView(StateLevel state)
    {
        currentState = state;

        switch (currentState)
        {
            case StateLevel.Close:
                _closeIcon.SetActive(true);
                break;
            case StateLevel.Open:
                _closeIcon.SetActive(false);
                break;
        }
    }
}
