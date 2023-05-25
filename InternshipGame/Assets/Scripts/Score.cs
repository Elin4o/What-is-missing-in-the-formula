using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;

    public Text scoreText;

    public Text finalScoreText;

    public Text highscoreText;

    private void Start()
    {
        SetScoreText();
    }
    void SetScoreText()
    {
        scoreText.text = "Резултат\n " + score;
    }

    public void SetFinalScoreText() 
    {
        finalScoreText.text = "Резултат\n" + score;
    }

    public void AddScore(int ammount)
    {
        score += ammount;
        SetScoreText();
    }

    public void CheckHighscore()
    {
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore",score);
        }
    }

    public void SetHighscore()
    {
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            highscoreText.text = "Най-висок резултат\n" + score;
        }
        else
        {
            highscoreText.text = "Най-висок резултат\n" + PlayerPrefs.GetInt("Highscore", 0);
        }
    }
}
