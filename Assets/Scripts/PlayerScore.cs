using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int totalScore;

    int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    public void ScoreCalculate(float dist)
    {
        score = Mathf.RoundToInt(dist);
        
        if (dist >= 40)
        {
            totalScore += score;
            scoreText.text = "Current Score: " + totalScore;
        }
        else if ((dist < 40) && (dist >= 25))
        {
            totalScore += score * 2;
            scoreText.text = "Current Score: " + totalScore;
        }
        else if ((dist < 25) && (dist >= 10))
        {
            totalScore += score * 3;
            scoreText.text = "Current Score: " + totalScore;
        }
        else if ((dist < 10))
        {
            totalScore += score * 5;
            scoreText.text = "Current Score: " + totalScore;
        }
    }
    public void pointPickup(int ItemValue)
    {
        totalScore += ItemValue;
        scoreText.text = "Current Score: " + totalScore;
    }
}
