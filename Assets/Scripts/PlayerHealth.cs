using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text winText;
    //public Text finalScore;
    public GameObject finalScore;
    public Button nextLevel;
    private PlayerScore playerScore;
    public Text highScoreText;

    void Start() {
        winText.gameObject.SetActive(false);
        finalScore.SetActive(false);
        nextLevel.gameObject.SetActive(false);   
        playerScore = gameObject.GetComponent<PlayerScore>();
        PlayerPrefs.SetInt("topScore", 0);

        if (highScoreText != null)
        {
            highScoreText.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "spike")
        {
            if (SceneManager.GetActiveScene().name == "Level_Endless")
            {
                endlessDeath();
            }
            else
            {
                playerDeath();
            }
        }
        if (col.gameObject.tag == "goal")
        {
            winText.gameObject.SetActive(true);
            finalScore.gameObject.SetActive(true);
            nextLevel.gameObject.SetActive(true);
            finalScore.GetComponent<Text>().text = "final score: " + playerScore.totalScore;
        }
    }

    public void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }


    public void playerDeath()
    {
        Destroy(gameObject);

        RestartScene();
    }

    public void endlessDeath()
    {
        Destroy(gameObject);
        winText.gameObject.SetActive(true);
        finalScore.gameObject.SetActive(true);
        nextLevel.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        finalScore.GetComponent<Text>().text = "final score: " + playerScore.totalScore;

        if (highScoreText.gameObject != null)
        {
            highScoreText.gameObject.SetActive(true);
        }

        var Highscore = PlayerPrefs.GetInt("Player Score");
        if (Highscore < playerScore.totalScore)
        {
            PlayerPrefs.SetInt("topScore", playerScore.totalScore);
            highScoreText.text = "Highest Score: " + playerScore.totalScore;
        }
    }

}
