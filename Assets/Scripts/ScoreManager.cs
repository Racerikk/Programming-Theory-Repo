using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    float interval;
    [HideInInspector] public int score;
    [HideInInspector] public bool isGameOver;
    [SerializeField] TextMeshProUGUI scoreCounter;
    [SerializeField] TextMeshProUGUI loseGameText;
    void Start()
    {
        instance = this;
        interval = MainManager.Instance.scoreAddTimer;
        StartCoroutine(ScoreCounter());
    }

    IEnumerator ScoreCounter()
    {
        yield return new WaitForSeconds(interval);
        if (!isGameOver)
        {
            score++;
            scoreCounter.text = "Score: " + score;
            StartCoroutine(ScoreCounter());
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        if(score > MainManager.Instance.highScore)
        {
            loseGameText.text = "New Highscore!";
            MainManager.Instance.NewHighScoreReached();
        }
        else
        {
            loseGameText.text = "You Lost!";
        }
    }
}
