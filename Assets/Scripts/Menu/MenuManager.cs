using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _buttonStart;

    [Header("Dont Ready")]
    [SerializeField] private GameObject _panelDontReady;
    [SerializeField] private Button _buttonDontReadyClose;

    [Header("Change Color")]
    [SerializeField] private ChangeCubeColor _changeCubeColor;
    [SerializeField] private ChangeColor _changeColor;
    [SerializeField] private Button _buttonChangeColor;
    [SerializeField] private Button _buttonChangeColorClose;
    [SerializeField] private Button _buttonResetColor;
    [SerializeField] private GameObject _panelChangeColor;

    [Header("Shop")]
    [SerializeField] private Button _buttonShop;

    [Header("Settings")]
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private Button _buttonSettings;
    [SerializeField] private Button _ButtonSettingsClose;

    [Header("Score")]
    [SerializeField] private TMP_Text _bestScoreText;

    private void Awake()
    {
        UpdateScore();
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        int lastScore = EncryptedPlayerPrefs.GetEncryptedInt("LastScore");
        Wallet.CheckNewRecord(lastScore);
        Wallet.AddScore(lastScore);
        _bestScoreText.text = Wallet.BestScore.ToString();
    }

    private void Start()
    {
        _changeColor.ChangeMenuCubeColor();
        _buttonStart.onClick.AddListener(LoadGame);

        // Settings
        _buttonSettings.onClick.AddListener(ButtonSettings);
        _ButtonSettingsClose.onClick.AddListener(ButtonSettingsClose);

        // Change Color
        _buttonChangeColor.onClick.AddListener(ButtonChangeColor);
        _buttonChangeColorClose.onClick.AddListener(ButtonChangeColorClose);
        _buttonResetColor.onClick.AddListener(ResetColorButton);

        // Shop
        _buttonShop.onClick.AddListener(ButtonShop);

        // Dont ready
        _buttonDontReadyClose.onClick.AddListener(ButtonDontReadyClose);
    }
    #region ButtonMethods
    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ButtonChangeColor()
    {
        _panelChangeColor.SetActive(true);
    }

    private void ButtonChangeColorClose()
    {
        _panelChangeColor.SetActive(false);
    }

    private void ButtonShop()
    {
        _panelDontReady.SetActive(true);
    }

    private void ButtonDontReadyClose()
    {
        _panelDontReady.SetActive(false);
    }

    private void ResetColorButton()
    {
        _changeCubeColor.ResetCube();
    }

    private void ButtonSettings()
    {
        _panelSettings.SetActive(true);
    }

    private void ButtonSettingsClose()
    {
        _panelSettings.SetActive(false);
    }
    #endregion
}
