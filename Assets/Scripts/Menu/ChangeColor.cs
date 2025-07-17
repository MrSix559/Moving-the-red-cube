using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private Button _buttonClosePanelSuccessfullyPurchased;
    [SerializeField] private GameObject _panelSuccessfullyPurchased;

    [SerializeField] private Image _cubeMenu;
    [SerializeField] private Sprite _defaultCubeMenuSprite;
    [SerializeField] private Sprite _cubeMenuTexture;
    [SerializeField] private ChangeCubeColor _changeCubeColor;
    [SerializeField] private int _price;
    [SerializeField] private TMP_Text _allScoreText;

    private void OnEnable()
    {
        ChangeCubeColor.OnResetCube += ResetCube;
    }

    private void OnDisable()
    {
        ChangeCubeColor.OnResetCube -= ResetCube;
    }

    private void ResetCube()
    {
        EncryptedPlayerPrefs.DeleteEncryptedKey("CubeColor");

        _cubeMenu.sprite = _defaultCubeMenuSprite;
        _cubeMenu.color = new Color(255, 255, 255, 255);
    }

    private void Start()
    {
        UpdateAllScore();
        _buttonBuy.onClick.AddListener(Buy);
        _buttonClosePanelSuccessfullyPurchased.onClick.AddListener(CloseSuccessfullyPurchasedPanel);
    }

    private void Buy()
    {
        if(Wallet.TryBuy(_price))
        {
            _changeCubeColor.ApplyColor();
            ChangeMenuCubeColor();
            _panelSuccessfullyPurchased.SetActive(true);
            UpdateAllScore();
        }
    }

    private void UpdateAllScore()
    {
        _allScoreText.text = $"All Score: {Wallet.AllScore.ToString()}";
    }

    public void ChangeMenuCubeColor()
    {
        if (EncryptedPlayerPrefs.HasEncryptedKey("CubeColor"))
        {
            _cubeMenu.sprite = _cubeMenuTexture;
            _cubeMenu.color = ChangeCubeColor.ParseColor(EncryptedPlayerPrefs.GetEncryptedString("CubeColor"));
        } 
        else
        {
            _cubeMenu.sprite = _defaultCubeMenuSprite;
        }
    }

    private void CloseSuccessfullyPurchasedPanel()
    {
        _panelSuccessfullyPurchased.SetActive(false);
    }
}
