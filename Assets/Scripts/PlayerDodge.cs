using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    Rigidbody rb;
    float dodgeDelay;
    float dodgeDelayDefault = .5f;

    public float dodgeTime;
    float dodgeTimeDefault = .1f;
    bool canDodge = true;

    public float boostTimer;
    float boostTimerDefault = .5f;
    bool canBoost = true;

    float raycastRange = 50f;
    public float dodgeDistance = 150f;

    Vector3 startPos;
    Vector3 endPosRight;
    Vector3 endPosLeft;
    float distance = 1f;

    float lerpTime = 0.1f;
    float currentLerpTime;
    float perc;

    private playerMovement PlayerMovement;
    private PlayerScore playerScore;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerMovement = gameObject.GetComponent<playerMovement>();
        playerScore = gameObject.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        startPos = transform.position;
        endPosRight = transform.position + Vector3.right * distance;
        endPosLeft = transform.position + Vector3.right * -distance;

        if (canDodge == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space))
            {
                dodgeRight();
                canDodge = false;
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
                boostTimer = .6f;
                canBoost = true;
            }
        }


    }


    void dodgeRight()
    {

        boostCheck();
        canBoost = false;
        boostTimer = boostTimerDefault;

        dodgeTime += Time.deltaTime;
        perc = dodgeTime / lerpTime;

        rb.transform.position = Vector3.Lerp(startPos, endPosRight, perc);

        if (dodgeTime >= dodgeTimeDefault)
        {
            dodgeDelay = dodgeDelayDefault;
            dodgeTime = 0;
        }

    }

    void dodgeLeft()
    {
        boostCheck();
        canBoost = false;
        boostTimer = boostTimerDefault;

        dodgeTime += Time.deltaTime;
        perc = dodgeTime / lerpTime;

        rb.transform.position = Vector3.Lerp(startPos, endPosLeft, perc);

        if (dodgeTime >= dodgeTimeDefault)
        {
            dodgeDelay = dodgeDelayDefault;
            dodgeTime = 0;
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
                //Debug.Log(hit.distance);

                playerScore.ScoreCalculate(hit.distance);

                PlayerMovement.baseMaxSpeed = PlayerMovement.baseMaxSpeed + (10 - (hit.distance / 5));
                PlayerMovement.maxSpeed = PlayerMovement.maxSpeed + (20 - ((hit.distance * 2) / 5));

            }

        }

    }

}
