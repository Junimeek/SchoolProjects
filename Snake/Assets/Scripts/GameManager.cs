using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score;
    [SerializeField] private Text ScoreText;
    private Snake snakeScript;

    private void Awake()
    {
        Score = 0;
        ScoreText.text = "SCORE: 0";
    }

    public void UpdateScore()
    {
        Score = FindObjectOfType<Snake>()._segments.Count - 6;
        ScoreText.text = "SCORE: " + Score.ToString();
    }
}
