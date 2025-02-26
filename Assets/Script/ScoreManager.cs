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

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + score.ToString();
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

}