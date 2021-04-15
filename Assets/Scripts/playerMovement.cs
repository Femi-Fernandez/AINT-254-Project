using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float horizontalSpeed = 12.0f;

    //float forwardSpeed;
    public float baseForwardSpeed = 40.0f;
 

    public float baseMaxSpeed = 200.0f;
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

    public bool oldOrNew;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

      
        //speedtext = this.GetComponent<Text>();


        playerPause = gameObject.GetComponent<PlayerPause>();
        //speed = baseMaxSpeed;
        //forwardSpeed = baseForwardSpeed;
        jetBoost.SetActive(true);
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
        if (!oldOrNew)
        {
            player_model.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -2f);
        }

        if (rb.velocity.magnitude < baseMaxSpeed)
        {
                rb.AddForce(transform.forward* baseForwardSpeed, ForceMode.Acceleration);
        }

   
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-transform.forward * baseForwardSpeed, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {         
            rb.AddForce(transform.right * horizontalSpeed, ForceMode.Acceleration);

            //player_model.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -30);
           // player_model.transform.rotation = Quaternion.Lerp(player_model.transform.rotation, Quaternion.Euler(0.0f, 0.0f, -30), Time.deltaTime*10);
            if (oldOrNew)
            {
                player_model.transform.rotation = Quaternion.Lerp(player_model.transform.rotation, Quaternion.Euler(0.0f, 0.0f, -30), Time.deltaTime * 10);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * horizontalSpeed, ForceMode.Acceleration);
            //player_model.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 30);
            //player_model.transform.rotation = Quaternion.Lerp(player_model.transform.rotation, Quaternion.Euler(0.0f, 0.0f, 30), Time.deltaTime * 10);
            if (oldOrNew)
            {
                player_model.transform.rotation = Quaternion.Lerp(player_model.transform.rotation, Quaternion.Euler(0.0f, 0.0f, 30), Time.deltaTime * 10);
            }
        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) /*|| !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) */)
        {            
            rb.velocity = new Vector3(rb.velocity.x * .95f, rb.velocity.y, rb.velocity.z);
            //player_model.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
            if (oldOrNew)
            {
                player_model.transform.rotation = Quaternion.Lerp(player_model.transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0), Time.deltaTime * 10);
            }
           // player_model.transform.rotation = Quaternion.Lerp(player_model.transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0), Time.deltaTime * 10);
        }
    }

}
