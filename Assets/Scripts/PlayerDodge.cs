using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    Rigidbody rb;
    float dodgeDelay;
    float dodgeDelayDefault = 1.0f;

    float dodgeTime;
    float dodgeTimeDefault = 0.1f;
    bool canDodge = true;

    public float boostTimer;
    float boostTimerDefault = 1.0f;
    bool canBoost = true;

    float raycastRange = 50f;
    public float dodgeDistance = 150f;

    private playerMovement PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerMovement = gameObject.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDodge == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space))
            {
                dodgeRight();
                
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space))
            {
               dodgeLeft();
            }
        }
        
        if (canDodge == false)
        {
            dodgeDelay -= Time.deltaTime;
            if (dodgeDelay < 0)
            {
                dodgeDelay = 0.0f;
                canDodge = true;
            }
        }

        if (canBoost == false)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                boostTimer = 1.1f;
                canBoost = true;
            }
        }

        
    }


    void dodgeRight()
    {
        
        boostCheck();
        canBoost = false;
        boostTimer = boostTimerDefault;

        dodgeTime -= Time.deltaTime;

        rb.transform.position += (transform.right * dodgeDistance) *Time.deltaTime;
        //transform.Translate(new Vector3(1, 0, 0));

        if (dodgeTime <= 0)
        {
            dodgeDelay = dodgeDelayDefault;
            dodgeTime = dodgeTimeDefault;
            canDodge = false;     
        }
        
    }

    void dodgeLeft()
    {
        boostCheck();
        canBoost = false;
        boostTimer = boostTimerDefault;

        dodgeTime -= Time.deltaTime;
        //transform.Translate(new Vector3(-1, 0, 0));
        rb.transform.position += (-transform.right * dodgeDistance) * Time.deltaTime;

        if (dodgeTime <= 0)
        {
            dodgeDelay = dodgeDelayDefault;
            dodgeTime = dodgeTimeDefault;
            canDodge = false;
        }
        
    }

    void boostCheck()
    {
        if (canBoost == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, raycastRange))
            {
                Debug.Log(hit.distance);
                

                PlayerMovement.baseMaxSpeed = PlayerMovement.baseMaxSpeed + (10 - (hit.distance / 5));
                PlayerMovement.maxSpeed = PlayerMovement.maxSpeed + (20 - ((hit.distance * 2) / 5));

            }

        }

    }

}
