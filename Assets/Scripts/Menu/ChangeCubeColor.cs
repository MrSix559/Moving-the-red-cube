using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCubeColor : MonoBehaviour
{
    public static event Action OnResetCube;

    [SerializeField] private Image _cubeMenu;
    [SerializeField] private Image _cubeIcon;
    [SerializeField] private Slider _sliderR;
    [SerializeField] private Slider _sliderG;
    [SerializeField] private Slider _sliderB;
    private Color _color = new(1, 1, 1, 1);

    private void Update()
    {
        _color.r = _sliderR.value;
        _color.g = _sliderG.value;
        _color.b = _sliderB.value;
        _cubeIcon.color = _color;
    }

    public void ApplyColor()
    {
        EncryptedPlayerPrefs.SetEncryptedString("CubeColor", _color.ToString());
    }

    public void ResetCube()
    {
        OnResetCube?.Invoke();
    }

    public static Color ParseColor(string colorString)
    {
        // ќжидаемый формат: "RGBA(r, g, b, a)"
        if (!colorString.StartsWith("RGBA(") || !colorString.EndsWith(")"))
            throw new System.FormatException("Invalid color format");

        string inner = colorString.Substring(5, colorString.Length - 6);
        string[] parts = inner.Split(',');

        if (parts.Length != 4)
            throw new System.FormatException("Invalid RGBA components count");

        float r = float.Parse(parts[0].Replace('.', ','));
        float g = float.Parse(parts[1].Replace('.', ','));
        float b = float.Parse(parts[2].Replace('.', ','));
        float a = float.Parse(parts[3].Replace('.', ','));

        return new Color(r, g, b, a);
    }
}
