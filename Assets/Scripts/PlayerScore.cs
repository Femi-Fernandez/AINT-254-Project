using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    int totalScore;

    int score;
    private PlayerDodge playerDodge;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        playerDodge = gameObject.GetComponent<PlayerDodge>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreCalculate(float dist)
    {
        score = Mathf.RoundToInt(dist);
        totalScore += score;

        scoreText.text = "Current Score: " + totalScore;
    }
}
