using UnityEngine;

public static class Wallet
{
    private static int _bestScore { get => EncryptedPlayerPrefs.GetEncryptedInt("BestScore"); set => EncryptedPlayerPrefs.SetEncryptedInt("BestScore", value); }
    private static int _allScore { get => EncryptedPlayerPrefs.GetEncryptedInt("AllScore"); set => EncryptedPlayerPrefs.SetEncryptedInt("AllScore", value); }

    public static int BestScore => _bestScore;
    public static int AllScore => _allScore;

    public static void CheckNewRecord(int lastScore)
    {
        if(_bestScore < lastScore)
            _bestScore = lastScore;
    }

    public static void AddScore(int score)
    {
        _allScore += score;
    }

    public static bool TryBuy(int price)
    {
        if (price > _allScore)
        {
            Debug.Log("Dont have a score");
            return false;
        }

        _allScore -= price;
        return true;
    }
}
