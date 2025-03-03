using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsHandler : MonoBehaviour
{
    public static SoundsHandler sound;

    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _soundsMusic;

    [SerializeField] private Slider _volumeSlider;

    [Header("Sounds")]
    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _boomb;
    [SerializeField] private AudioClip _success;
    [SerializeField] private AudioClip _false;

    [Header("View Settings")]
    [SerializeField] private Button _soundsBtn;
    [SerializeField] private Button _vibrationBtn;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private bool isSound = true;
    private bool isVibration = true;

    public enum NameSoundGame
    {
        Click,
        Boom,
        Success,
        False
    }

    public enum TypeVibration
    {
        VibratePop,
        VibratePeek
    }

    private void Awake()
    {
        if (sound == null) sound = this;

        Vibration.Init();

        _soundsBtn.onClick.AddListener(() =>
        {
            ActiveSounds();
        });

        _vibrationBtn.onClick.AddListener(() =>
        {
            ActiveVibration();
        });
    }

    public void VolumeChange()
    {
        _backgroundMusic.volume = _volumeSlider.value;
        _soundsMusic.volume = _volumeSlider.value;

        if (_volumeSlider.value == 0)
        {
            _soundsBtn.transform.GetChild(0).GetComponent<Image>().sprite = _offSprite;
        }
        else
        {
            _soundsBtn.transform.GetChild(0).GetComponent<Image>().sprite = _onSprite;
        }
    }

    public void ActiveSounds()
    {
        isSound = !isSound;
        switch (isSound)
        {
            case true:
                _backgroundMusic.Play();
                _volumeSlider.value = 1f;
                break;
            case false:
                _volumeSlider.value = 0;
                _backgroundMusic.Stop();
                break;
        }
    }

    public void ActiveVibration()
    {
        isVibration = !isVibration;

        if (isVibration == true)
        {
            _vibrationBtn.transform.GetChild(0).GetComponent<Image>().sprite = _onSprite;
        }
        else
        {
            _vibrationBtn.transform.GetChild(0).GetComponent<Image>().sprite = _offSprite;
        }
    }

    public void PlayVibration(TypeVibration typeVibration)
    {
        if (isVibration)
        {
            switch (typeVibration)
            {
                case TypeVibration.VibratePop:
                    Vibration.VibratePop();
                    Debug.Log("Vibrate Pop");
                    break;
                case TypeVibration.VibratePeek:
                    Vibration.VibratePeek();
                    Debug.Log("Vibrate Peek");
                    break;
            }
        }
    }

    public void PlayShotSound(NameSoundGame nameSoundG)
    {
        if (isSound)
        {
            switch (nameSoundG)
            {
                case NameSoundGame.Click:
                    _soundsMusic.PlayOneShot(_click);
                    break;
                case NameSoundGame.Boom:
                    _soundsMusic.PlayOneShot(_boomb);
                    break;
                case NameSoundGame.Success:
                    _soundsMusic.PlayOneShot(_success);
                    break;
                case NameSoundGame.False:
                    _soundsMusic.PlayOneShot(_false);
                    break;
            }
        }
    }
}
