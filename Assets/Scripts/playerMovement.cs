﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float horizontalSpeed = 12.0f;

    float forwardSpeed;
    public float boostForwardSpeed = 40.0f;
    public float baseForwardSpeed = 20.0f;
 

    public float speed;
    public float maxSpeed = 200.0f;
    public float baseMaxSpeed = 100.0f;
    public float currentSpeed;

    //public float tiltTime;
    //float tiltDuration = .5f;
    //float tiltResetDuration = 0.25f;
    //float perc;
    
    public Text speedtext;
    public GameObject jetBoost;
    public GameObject player_model;
    //public Text maxSpeedtext;
    private PlayerPause playerPause;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

      
        //speedtext = this.GetComponent<Text>();

        forwardSpeed = baseForwardSpeed;
        playerPause = gameObject.GetComponent<PlayerPause>();
    }
     
    // Update is called once per frame
    void FixedUpdate()
    {
        currentSpeed = rb.velocity.magnitude;
        if (playerPause.paused == false)
        {
            movePlayer();
        }
        speedtext.text = "Current speed: " + Mathf.RoundToInt(currentSpeed);
        //maxSpeedtext.text = "Max speed: " + Mathf.RoundToInt(baseMaxSpeed);
        
    }

    void movePlayer()
    {
        player_model.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -2f);
        //when boost button is pressed, set speed and acceleration values to their boost values
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = maxSpeed;
            forwardSpeed = boostForwardSpeed;
            jetBoost.SetActive(true);
        }
        else
        {
            //when boost is released, reset to base values.
            speed = baseMaxSpeed;
            forwardSpeed = baseForwardSpeed;
            jetBoost.SetActive(false);
        }

        //if speed is less than max speed allow acceleration
        if (rb.velocity.magnitude < speed)
        {
                rb.AddForce(transform.forward* forwardSpeed, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-transform.forward * forwardSpeed, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {         
            rb.AddForce(transform.right * horizontalSpeed, ForceMode.Acceleration);          
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * horizontalSpeed, ForceMode.Acceleration);
        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) /*|| !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) */)
        {            
            rb.velocity = new Vector3(rb.velocity.x * .95f, rb.velocity.y, rb.velocity.z);            
        }
    }

}
