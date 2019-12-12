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

    void Start() {
        winText.gameObject.SetActive(false);
        finalScore.SetActive(false);
        nextLevel.gameObject.SetActive(false);
        playerScore = gameObject.GetComponent<PlayerScore>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "spike")
        {
            Destroy(gameObject);
            RestartScene();
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
}
