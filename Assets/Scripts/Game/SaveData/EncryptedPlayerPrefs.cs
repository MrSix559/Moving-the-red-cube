using UnityEngine;
using System;
using System.Text;

public static class EncryptedPlayerPrefs
{
    private static string EncodeKey(string key)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
    }

    // Encrypted string in Base64
    private static string Encrypt(string value)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    // Uncrypted string from Base64
    private static string Decrypt(string value)
    {
        try
        {
            byte[] data = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(data);
        }
        catch
        {
            Debug.LogWarning("EncryptedPlayerPrefs: Decrypt failed");
            return "";
        }
    }

    // ---------------- INT ----------------

    public static void SetEncryptedInt(string key, int value)
    {
        string encodedKey = EncodeKey(key);
        string encryptedValue = Encrypt(value.ToString());
        PlayerPrefs.SetString(encodedKey, encryptedValue);
        PlayerPrefs.Save();
    }

    public static int GetEncryptedInt(string key, int defaultValue = 0)
    {
        string encodedKey = EncodeKey(key);
        if (!HasEncryptedKey(key)) return defaultValue;

        string encrypted = PlayerPrefs.GetString(encodedKey);
        string decrypted = Decrypt(encrypted);
        if (int.TryParse(decrypted, out int result))
            return result;

        return defaultValue;
    }

    public static bool HasEncryptedKey(string key)
    {
        return PlayerPrefs.HasKey(EncodeKey(key));
    }

    public static void DeleteEncryptedKey(string key)
    {
        PlayerPrefs.DeleteKey(EncodeKey(key));
    }

    // ---------------- FLOAT ----------------

    public static void SetEncryptedFloat(string key, float value)
    {
        string encodedKey = EncodeKey(key);
        string encryptedValue = Encrypt(value.ToString());
        PlayerPrefs.SetString(encodedKey, encryptedValue);
        PlayerPrefs.Save();
    }

    public static float GetEncryptedFloat(string key, float defaultValue = 0f)
    {
        string encodedKey = EncodeKey(key);
        if (!PlayerPrefs.HasKey(encodedKey)) return defaultValue;

        string encrypted = PlayerPrefs.GetString(encodedKey);
        string decrypted = Decrypt(encrypted);
        if (float.TryParse(decrypted, out float result))
            return result;

        return defaultValue;
    }

    // ---------------- STRING ----------------

    public static void SetEncryptedString(string key, string value)
    {
        string encodedKey = EncodeKey(key);
        string encryptedValue = Encrypt(value);
        PlayerPrefs.SetString(encodedKey, encryptedValue);
        PlayerPrefs.Save();
    }

    public static string GetEncryptedString(string key, string defaultValue = "")
    {
        string encodedKey = EncodeKey(key);
        if (!PlayerPrefs.HasKey(encodedKey)) return defaultValue;

        string encrypted = PlayerPrefs.GetString(encodedKey);
        string decrypted = Decrypt(encrypted);

        return string.IsNullOrEmpty(decrypted) ? defaultValue : decrypted;
    }
}
