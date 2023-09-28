using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int highScore;

    //setter for highScore
    public int HighScore
    {
        get { return highScore; }
        set { highScore = value; }
    }

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
            // Load the high score from PlayerPrefs
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            UpdateScoreText();
        
    }

    public void UpdateScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        else
        {
            highScore += score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        PlayerPrefs.Save();
        UpdateScoreText();
    }

    public void ResetScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        UpdateScoreText();
    }

    public void StartScore(int score)
    {
        highScore = score;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + highScore;
        }
    }
}
