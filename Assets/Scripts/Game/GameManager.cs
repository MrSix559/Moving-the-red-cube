using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Cube Custom Color")]
    [SerializeField] private Renderer _player;
    [SerializeField] private Renderer _blocksPlayer;
    private Color _colorPlayer;
    [Header("Sounds")]
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource[] _sounds;
    private bool _tryChangeColor;

    private void Start()
    {
        _player.material = new Material(_player.sharedMaterial);
        _blocksPlayer.material = new Material(_blocksPlayer.sharedMaterial);
        LoadSaves();
    }

    private void LoadSaves()
    {
        // Set FPS
        Application.targetFrameRate = EncryptedPlayerPrefs.GetEncryptedInt("Fps");

        // Load sounds
        _music.mute = EncryptedPlayerPrefs.GetEncryptedInt("Music") == 0;
        foreach (var sound in _sounds)
        {
            sound.mute = EncryptedPlayerPrefs.GetEncryptedInt("Sound") == 0;
        }

        // Load player color
        if (EncryptedPlayerPrefs.HasEncryptedKey("CubeColor"))
        {
            _colorPlayer = ChangeCubeColor.ParseColor(EncryptedPlayerPrefs.GetEncryptedString("CubeColor"));
            _player.sharedMaterial.color = _colorPlayer;
        }
    }
}
