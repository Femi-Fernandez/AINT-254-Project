using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    private int popUpCounter;
    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        waitTimeReset();
    }

    public void waitTimeReset()
    {
        waitTime = 3f;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpCounter){
                popUps[i].SetActive(true);
            }
            else{
                popUps[i].SetActive(false);
            }
        }


        if (popUpCounter == 0)
        {
            if (waitTime <= 0)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    waitTimeReset();
                    popUpCounter++;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpCounter == 1)
        {
            if (waitTime <= 0)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
                {
                    waitTimeReset();
                    popUpCounter++;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpCounter == 2)
        {
            if (waitTime <= 0)
            {
                waitTimeReset();
                popUpCounter++;        
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpCounter == 3)
        {
            if (waitTime <= 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    waitTimeReset();
                    popUpCounter++;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpCounter == 4)
        {
            if (waitTime <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    waitTimeReset();
                    popUpCounter++;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpCounter == 5)
        {
            if (waitTime <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    waitTimeReset();
                    popUpCounter++;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
