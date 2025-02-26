using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player; 
    private float highestY;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    int score = 0;
    int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore : " + highscore.ToString();
    }

    void Update()
    {
        if (player.position.y > highestY)
        {
            highestY = player.position.y;
            score = Mathf.FloorToInt(highestY);
            scoreText.text = "Score : " + score.ToString();
        }
    }
    public void SaveHighscore()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
        highscoreText.text = "Highscore : " + highscore.ToString();
    }
    
}