using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class Score
{
    private static int _score;

    public static Action<int> OnAddScoreEvent;

    public static void AddScore(int amount)
    {
        _score += amount;
        OnAddScoreEvent?.Invoke(_score);
    }

    public static void ResetScore() {_score = 0;}
}