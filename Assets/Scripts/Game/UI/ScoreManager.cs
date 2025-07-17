using System;
using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnScoreChange;

    [SerializeField] private float _timeForAddScore;
    private int _score;
    private Coroutine _addScoreCoroutine;

    private void Start()
    {
        _addScoreCoroutine = StartCoroutine(AddScoreAfterTime());
    }

    private void OnEnable()
    {
        DeathPlayer.OnDeath += StopAddScoreCoroutine;
    }

    private void OnDisable()
    {
        DeathPlayer.OnDeath -= StopAddScoreCoroutine;
    }

    private IEnumerator AddScoreAfterTime()
    {
        WaitForSeconds timeForAddScore = new WaitForSeconds(_timeForAddScore);
        while (!DeathPlayer.checkIsDead)
        {
            yield return timeForAddScore;
            _score++;
            OnScoreChange?.Invoke(_score);
        }
    }

    private void StopAddScoreCoroutine()
    {
        if (_addScoreCoroutine != null) StopCoroutine(_addScoreCoroutine);
    }

}
