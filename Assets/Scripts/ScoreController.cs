using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreValue = 100;
    private int score;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            score = 0;
        } else
        {
            score = PlayerPrefs.GetInt("Score");
        }
    }


    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore()
    {
        score += scoreValue;
        PlayerPrefs.SetInt("Score", score);
    }
}
