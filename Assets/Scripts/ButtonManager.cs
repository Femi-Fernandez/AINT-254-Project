using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public GameObject mainButtons;
    public GameObject levelSelectButtons;
    // Start is called before the first frame update
    void Start()
    {
        mainButtons.SetActive(true);
        levelSelectButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void levelSelect()
    {
        mainButtons.SetActive(false);
        levelSelectButtons.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }
}
