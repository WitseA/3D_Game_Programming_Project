using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreValue = 100;
    private int score = 0;
    

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore()
    {
        score += scoreValue;
    }
}
