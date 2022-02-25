using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    //Score
    public float score;
    public int highScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        highScore = (int)score;
        scoreText.text = highScore.ToString();

        if (PlayerPrefs.GetInt("score") <= highScore)
        {
            PlayerPrefs.SetInt("score", highScore);
        }
    }

    public void HighScoreFun()
    {
        highScoreText.text = PlayerPrefs.GetInt("score").ToString();
    }
}
