using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartOfEndScene : MonoBehaviour
{
    public TextMeshPro scoreText;
    
    void Start()
    {
        scoreText.text = "YOUR SCORE: " + PlayerPrefs.GetInt("Score");
    }
}
