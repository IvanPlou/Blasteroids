using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This code is not finished and currently not working.
public class Score
{
    static int _score;
    //[SerializeField] static TextMeshProUGUI scoreUI;

    public static Action<int> OnAddScoreEvent;

    public static void AddScore(int amount)
    {
        _score += amount;
        OnAddScoreEvent?.Invoke(_score);
        //scoreUI.text = $"Score: {_score.ToString()}";
    }

    public void ResetScore() {_score = 0;}
}