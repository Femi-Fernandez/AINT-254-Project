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
        mainMenu();
    }

    public void levelSelect()
    {
        mainButtons.SetActive(false);
        levelSelectButtons.SetActive(true);
    }
    
    public void mainMenu()
    {
        mainButtons.SetActive(true);
        levelSelectButtons.SetActive(false);
    }
}
