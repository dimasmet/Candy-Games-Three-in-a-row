using UnityEngine;
using UnityEngine.UI;

public class MenuView : ScreenPanel
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _soundsBtn;

    [SerializeField] private Settings settings;

    private void Awake()
    {
        _playBtn.onClick.AddListener(() =>
        {
            ScreensViewHandler.UI.OpenPanel(ScreensViewHandler.NamePanel.Levels);

            if (PlayerPrefs.GetInt("ShowFirstRules") != 1)
            {
                GameRulesControl.I.ShowRules(false);
                PlayerPrefs.SetInt("ShowFirstRules", 1);
            }

            SoundsHandler.sound.PlayShotSound(SoundsHandler.NameSoundGame.Click);
        });

        _soundsBtn.onClick.AddListener(() =>
        {
            settings.OpenSettingsSound();
        });
    }
}
