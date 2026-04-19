using System;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Button saveSettingsButton;

        private void Start()
        {
            gameSettings = Resources.Load<GameSettings>("GameSettings");

            saveSettingsButton.onClick.AddListener(SaveAndGoBack);
            musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            sfxSlider.onValueChanged.AddListener(OnSfxVolumeChanged);

            Debug.Log($"Music: {gameSettings.VolumeOfMusic}, SFX: {gameSettings.VolumeOfSFX}");

            if(gameSettings != null)
            {
                SoundManager.Instance.GetSfx().volume = gameSettings.VolumeOfSFX;
                SoundManager.Instance.GetMusic().volume = gameSettings.VolumeOfMusic;
            }
        }

        private void OnSfxVolumeChanged(float arg0)
        {
            if(gameSettings != null)
            {
                gameSettings.VolumeOfSFX = arg0;
                SoundManager.Instance.GetSfx().volume = gameSettings.VolumeOfSFX;
            }
        }

        private void OnMusicVolumeChanged(float arg0)
        {
            if(gameSettings != null)
            {
                gameSettings.VolumeOfMusic = arg0;
                SoundManager.Instance.GetMusic().volume = gameSettings.VolumeOfMusic;
            }
        }

        private void SaveAndGoBack()
        {
            mainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}