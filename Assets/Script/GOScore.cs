using UnityEngine;
using TMPro;

public class GOScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int highscore = PlayerPrefs.GetInt("Highscore", 0);

        scoreText.text = "Score : " + lastScore.ToString();
        highscoreText.text = "Highscore : " + highscore.ToString();
    }
}