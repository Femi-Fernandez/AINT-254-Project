using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessSpeedCapCheck : MonoBehaviour
{
    public GameObject player;
    private float speedCheck = 100.0f;
    //public float playerCurrentSpeed;
    private float speedCheckIncrements = 25.0f;
    private float timer;
    private float timerReset = 20.0f;

    public Text speedCheckText;
    public Text countdown;
    // Start is called before the first frame update
    void Start()
    {
        //playerCurrentSpeed = player.GetComponent<Rigidbody>().velocity.z;
        timer = timerReset;
        speedCheckText.text = ("Reach " + speedCheck + " Speed before countdown ends!");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        countdown.text = ("Time left to speed check:" + Mathf.RoundToInt(timer));

        if (timer <= 0)
        {
            if (player != null)
            {
                if (player.GetComponent<Rigidbody>().velocity.magnitude <= speedCheck)
                {
                    //Debug.Log(playerCurrentSpeed);
                    //Debug.Log(player.GetComponent<Rigidbody>().velocity.magnitude);
                    player.GetComponent<PlayerHealth>().endlessDeath();
                    timer = 0;

                }
                else
                {
                    speedCheck += speedCheckIncrements;
                    speedCheckText.text = ("Reach " + speedCheck + " Speed before countdown ends!");
                    timer += timerReset;
                }
            }
           
        }
    }
}
