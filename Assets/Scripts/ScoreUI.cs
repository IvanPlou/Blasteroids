using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreUI;
    void Start()
    {
        Score.OnAddScoreEvent += ShowScore;
    }

    void ShowScore(int score)
    {
        _scoreUI.text = $"Score: {score}";
    }
}
