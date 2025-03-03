using UnityEngine;
using UnityEngine.UI;
#if !UNITY_ANDROID
using UnityEngine.iOS;
#endif

public class Settings : ScreenPanel
{
    [SerializeField] private Button _soundBtn;

    [SerializeField] private GameObject _settingsPanel;

    [SerializeField] private Button _openBtn;
    [SerializeField] private Button _closeBtn;

    [SerializeField] private Button _tutorialBtn;

    [SerializeField] private Button _privacyBtn;
    [SerializeField] private Button _termsBtn;
    [SerializeField] private Button _rateUsBtn;

    [Header("Reader")]
    [SerializeField] private GameObject _panelReader;
    [SerializeField] private Transform _container;
    [SerializeField] private Text _titleReaderText;
    [SerializeField] private Text _privacyText;
    [SerializeField] private Text _termsText;
    [SerializeField] private Button _closeReaderBtn;

    [Header("Sounds settings")]
    [SerializeField] private GameObject _panelSettingsSounds;
    [SerializeField] private Button _closeSettingsSounds;

    private void Awake()
    {
        _closeSettingsSounds.onClick.AddListener(() =>
        {
            _panelSettingsSounds.SetActive(false);
        });

        _rateUsBtn.onClick.AddListener(() =>
        {
            #if !UNITY_ANDROID
            Device.RequestStoreReview();
            #endif
        });

        _privacyBtn.onClick.AddListener(() =>
        {
            _panelReader.SetActive(true);
            _titleReaderText.text = "PRIVACY POLICY";
            _container.position = new Vector2(_container.position.x, 0);
            _privacyText.gameObject.SetActive(true);
            _termsText.gameObject.SetActive(false);
        });

        _termsBtn.onClick.AddListener(() =>
        {
            _panelReader.SetActive(true);
            _titleReaderText.text = "TERMS OF USE";
            _container.position = new Vector2(_container.position.x, 0);
            _privacyText.gameObject.SetActive(false);
            _termsText.gameObject.SetActive(true);
        });

        _closeReaderBtn.onClick.AddListener(() =>
        {
            _panelReader.SetActive(false);
        });

        Application.targetFrameRate = 90;

        _tutorialBtn.onClick.AddListener(() =>
        {
            GameRulesControl.I.ShowRules(true);
        });

        _openBtn.onClick.AddListener(() =>
        {
            _settingsPanel.SetActive(true);
        });

        _closeBtn.onClick.AddListener(() =>
        {
            _settingsPanel.SetActive(false);
        });

        _soundBtn.onClick.AddListener(() =>
        {
            OpenSettingsSound();
        });
    }

    public void OpenSettingsSound()
    {
        _panelSettingsSounds.SetActive(true);
    }
}
