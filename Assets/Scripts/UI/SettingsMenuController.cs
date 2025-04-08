using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class SettingsMenuController : MonoBehaviour
{
    [Header("Slider & Text Bindings")]
    public Slider musicVolumeSlider;
    public TextMeshProUGUI musicVolumeValueText;

    public Slider sfxVolumeSlider;
    public TextMeshProUGUI sfxVolumeValueText;

    void Start()
    {
        if(AudioManager.Instance != null)
        {
            musicVolumeSlider.value = AudioManager.Instance.musicSource.volume;
            sfxVolumeSlider.value = AudioManager.Instance.uiSource.volume;
        }

        UpdateValueTexts();

        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    void OnMusicVolumeChanged(float value)
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.musicSource.volume = value;
        }
        musicVolumeValueText.text = Mathf.RoundToInt(value * 100) + "%";
    }

    void OnSFXVolumeChanged(float value)
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.uiSource.volume = value;
        }
        sfxVolumeValueText.text = Mathf.RoundToInt(value * 100) + "%";
    }

    void UpdateValueTexts()
    {
        musicVolumeValueText.text = Mathf.RoundToInt(musicVolumeSlider.value * 100) + "%";
        sfxVolumeValueText.text = Mathf.RoundToInt(sfxVolumeSlider.value * 100) + "%";
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
