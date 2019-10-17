using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    public float horizontalSpeed = 12.0f;

    float forwardSpeed;
    public float boostForwardSpeed = 40.0f;
    public float baseForwardSpeed = 20.0f;
 

    float speed;
    public float maxSpeed = 200.0f;
    public float baseMaxSpeed = 100.0f;
    public float currentSpeed;

    public Text speedtext;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        //speedtext = this.GetComponent<Text>();

        //set acceleration and max speed to default values
        //speed = baseMaxSpeed;
        forwardSpeed = baseForwardSpeed;
    }
     
    // Update is called once per frame
    void Update()
    {
        currentSpeed = rb.velocity.magnitude;
        movePlayer();
        speedtext.text = "Current speed: " + currentSpeed.ToString();
    }

    void movePlayer()
    {
        //when boost button is pressed, set speed and acceleration values to their boost values
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = maxSpeed;
            forwardSpeed = boostForwardSpeed;
        }
        else
        {
            //when boost is released, reset to base values.
            speed = baseMaxSpeed;
            forwardSpeed = baseForwardSpeed;
        }

        //if speed is less than max speed allow acceleration
        if (rb.velocity.magnitude < speed)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("here");
                //rb.AddForce(transform.forward * forwardSpeed, ForceMode.Acceleration);
                rb.AddForce(transform.forward* forwardSpeed, ForceMode.Acceleration);
            }
        }

        //left and right doesnt use forces as it needs to feel snappy
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += (transform.right * horizontalSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += (-transform.right * horizontalSpeed) * Time.deltaTime;

        }

    }
}
