using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class PlayerPause : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject pauseScreenUI;

    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        inGameUI.SetActive(true);
        pauseScreenUI.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {         
                pauseScreen();     
        }
    }

    public void pauseScreen()
    {
        paused = true;
        inGameUI.SetActive(false);
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0;        
    }
    public void unpauseScreen()
    {
        paused = false;
        inGameUI.SetActive(true);
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
