using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameUIManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonBackInMenu;

    [Header("Pause panel")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _buttonRestartInPause;
    [SerializeField] private Button _buttonBackInMenuInPause;
    [SerializeField] private Button _buttonPause;
    [SerializeField] private Button _buttonPauseClose;
    [SerializeField] private Text _scoreTextInPause;

    [Header("Control Player Buttons")]
    [SerializeField] private BlockController _blockController;
    [SerializeField] private Button _buttonBuildBlock;
    [SerializeField] private Button _buttonDestroyBlock;

    [Header("UI Score")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _deadScoreText;

    private void OnEnable()
    {
        ScoreManager.OnScoreChange += ChangeScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChange -= ChangeScoreText;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        _scoreText.text = $"Score: 0";
        _buttonRestart.onClick.AddListener(RestartButton);
        _buttonBackInMenu.onClick.AddListener(BackInMenuButton);

        _buttonRestartInPause.onClick.AddListener(RestartButton);
        _buttonBackInMenuInPause.onClick.AddListener(BackInMenuButton);
        _buttonPause.onClick.AddListener(PauseButton);
        _buttonPauseClose.onClick.AddListener(ClosePauseButton);
        _scoreTextInPause.text = $"Score: 0";

        _buttonBuildBlock.onClick.AddListener(_blockController.BuildBlockButton);
        _buttonDestroyBlock.onClick.AddListener(_blockController.DestroyBlockButton);
    }
    private void ChangeScoreText(int score)
    {
        _scoreText.text = $"Score: {score}";
        _scoreTextInPause.text = $"Score: {score}";
        _deadScoreText.text = $"Your Score: {score}";
    }

    public void OnControllButtons()
    {
        _buttonBuildBlock.enabled = true;
        _buttonDestroyBlock.enabled = true;
    }

    public void OffControllButtons()
    {
        _buttonBuildBlock.enabled = false;
        _buttonDestroyBlock.enabled = false;
    }

    private void PauseButton()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    private void ClosePauseButton()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
    }

    private void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void BackInMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
