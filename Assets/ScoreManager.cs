using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int maxCount = 3;

    private int score;
    public int count;

    void Start()
    {
        Reset();
        
    }

    // スコアを更新する

    public void UpdateScore(int addScore)
    {
        score += addScore;
        count++; 

        if (count % maxCount == 0)
        {
            ShowTotalScore();
            score = 0;
        }

    }

    private void ShowTotalScore()
    {

        scoreText.gameObject.SetActive(true);
        scoreText.text = "合計得点は: " + score + "!!";
    }

    private void Reset()
    {
        scoreText.gameObject.SetActive(false);
        score = 0;
        count = 0;
    }





}




