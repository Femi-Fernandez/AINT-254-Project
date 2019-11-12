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
    public GameObject jetBoost;
    //public Text maxSpeedtext;


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
        speedtext.text = "Current speed: " + Mathf.RoundToInt(currentSpeed);
        //maxSpeedtext.text = "Max speed: " + Mathf.RoundToInt(baseMaxSpeed);

    }

    void movePlayer()
    {
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

            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("here");
                //rb.AddForce(transform.forward * forwardSpeed, ForceMode.Acceleration);
                rb.AddForce(transform.forward* forwardSpeed, ForceMode.Acceleration);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("here");
            //rb.AddForce(transform.forward * forwardSpeed, ForceMode.Acceleration);
            rb.AddForce(-transform.forward * forwardSpeed, ForceMode.Acceleration);
        }

        //left and right doesnt use forces as it needs to feel snappy
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //float speed = horizontalSpeed;

            //transform.position += (transform.right * speed) * Time.deltaTime;
            rb.AddForce(transform.right * horizontalSpeed, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += (-transform.right * horizontalSpeed) * Time.deltaTime;
            rb.AddForce(-transform.right * horizontalSpeed, ForceMode.Acceleration);
        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x * .95f, rb.velocity.y, rb.velocity.z);
        }
    }
}
