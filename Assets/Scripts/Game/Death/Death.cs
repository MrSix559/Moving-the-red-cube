using UnityEngine;
using DG.Tweening;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _panelGameOver;

    [Header("Animation")]
    [SerializeField] private RectTransform _panel;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _hiddenOffsetY = -600f;

    private Vector2 _startPosition;
    private Vector2 _targetPosition;

    private void Awake()
    {
        _targetPosition = _panel.anchoredPosition;
        _startPosition = _targetPosition + new Vector2(0, _hiddenOffsetY);
        _panel.anchoredPosition = _startPosition;
    }

    private void OnEnable()
    {
        DeathPlayer.OnDeath += GameOver;
        ScoreManager.OnScoreChange += SaveLastScore;
    }

    private void OnDisable()
    {
        DeathPlayer.OnDeath -= GameOver;
        ScoreManager.OnScoreChange -= SaveLastScore;
    }

    private void SaveLastScore(int lastScore)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("LastScore", lastScore);
        PlayerPrefs.Save();
    }

    private void GameOver()
    {
        _panelGameOver.SetActive(true);
        _panel.DOAnchorPos(_targetPosition, _duration);
    }
}
