using UnityEngine;
using UnityEngine.UI;

public class LevelsView : ScreenPanel
{
    [SerializeField] private LevelButton[] lvlsBtn;

    [SerializeField] private Button _rulesBtn;

    [SerializeField] private Button _backBtn;

    private WrapLevels wrapLevels;

    [Header("Level info close")]
    [SerializeField] private Animator animInfoLevelClose;
    [SerializeField] private Button _closeInfoLevelBtn;

    public void InitButtons(WrapLevels wrapLevels)
    {
        this.wrapLevels = wrapLevels;
        UpdateViewButtons();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        UpdateViewButtons();
    }

    private void UpdateViewButtons()
    {
        for (int i = 0; i < lvlsBtn.Length; i++)
        {
            lvlsBtn[i].ContructInit(wrapLevels.levelInfos[i], this);
        }
    }

    public void ShowInfoForCloseLevel()
    {
        animInfoLevelClose.Play("Show");
        _closeInfoLevelBtn.interactable = true;

        SoundsHandler.sound.PlayShotSound(SoundsHandler.NameSoundGame.False);
        SoundsHandler.sound.PlayVibration(SoundsHandler.TypeVibration.VibratePop);
    }

    private void Awake()
    {
        _closeInfoLevelBtn.onClick.AddListener(() =>
        {
            _closeInfoLevelBtn.interactable = false;
            animInfoLevelClose.Play("Hide");
        });

        _backBtn.onClick.AddListener(() =>
        {
            ScreensViewHandler.UI.OpenPanel(ScreensViewHandler.NamePanel.Menu);
        });

        _rulesBtn.onClick.AddListener(() =>
        {
            GameRulesControl.I.ShowRules(true);
        });
    }
}
