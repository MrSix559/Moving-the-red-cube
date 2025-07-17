using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Sounds Music")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundToggle;

    [Header("FPS")]
    [SerializeField] private Toggle _fps60Toggle;
    [SerializeField] private Toggle _fps120Toggle;

    private void Start()
    {
        #region Sounds
        _musicToggle.onValueChanged.AddListener(OnVolumeMusicChange);
        _soundToggle.onValueChanged.AddListener(OnVolumeSoundsChange);

        _musicToggle.SetIsOnWithoutNotify(EncryptedPlayerPrefs.GetEncryptedInt("Music") == 1);
        _soundToggle.SetIsOnWithoutNotify(EncryptedPlayerPrefs.GetEncryptedInt("Sound") == 1);

        _musicSource.mute = EncryptedPlayerPrefs.GetEncryptedInt("Music") == 0;
        _soundSource.mute = EncryptedPlayerPrefs.GetEncryptedInt("Sound") == 0;

        #endregion
        #region FPS
        _fps60Toggle.onValueChanged.AddListener(On60FpsToggle);
        _fps120Toggle.onValueChanged.AddListener(On120FpsToggle);

        int targetFps = EncryptedPlayerPrefs.GetEncryptedInt("Fps", 60);
        Application.targetFrameRate = targetFps;
        (targetFps == 120 ? _fps120Toggle : _fps60Toggle).SetIsOnWithoutNotify(true);
        #endregion
    }

    private void OnVolumeMusicChange(bool isOn)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("Music", isOn ? 1 : 0);
        _musicSource.mute = !isOn;
    }

    private void OnVolumeSoundsChange(bool isOn)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("Sound", isOn ? 1 : 0);
        _soundSource.mute = !isOn;
    }

    private void On60FpsToggle(bool isOn)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("Fps", isOn ? 60 : 120);
        if (isOn) Application.targetFrameRate = 60;
    }

    private void On120FpsToggle(bool isOn)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("Fps", isOn ? 120 : 60);
        if (isOn) Application.targetFrameRate = 120;
    }
}
