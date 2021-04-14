using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    Rigidbody rb;
    float dodgeDelay;
    float dodgeDelayDefault = .5f;

     float dodgeTime;
    public float dodgeTimeDefault = .1f;
    bool canDodge = true;

    public float boostTimer;
    float boostTimerDefault = .5f;
    bool canBoost = true;

    float raycastRange = 50f;
    //public float dodgeDistance = 150f;

    Vector3 startPos;
    Vector3 endPosRight;
    Vector3 endPosLeft;
    public float distance = 1f;

    float perc;

    private playerMovement playerMovement;
    private PlayerScore playerScore;

    private PlayerDodgeRender dodgeRender;
    public Transform rayStart;

    public timeManager TimeManager;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        playerMovement = gameObject.GetComponent<playerMovement>();
        playerScore = gameObject.GetComponent<PlayerScore>();
        dodgeRender = gameObject.GetComponent<PlayerDodgeRender>();
    }

    // Update is called once per frame
    void Update()
    {
        startPos = transform.position;
        //endPosRight = transform.position + Vector3.right * distance;
        endPosRight = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        //endPosLeft = transform.position + Vector3.right * -distance;
        endPosLeft = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);

        if (canDodge == true)
        {
            if ((Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Space)) || (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space)))
            {
                //dodgeRight();

                StartCoroutine(Dodge(startPos, endPosRight));
                
                canDodge = false;
            }
            if ((Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Space)) || (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space)))
            {
                //dodgeLeft();
                StartCoroutine(Dodge(startPos, endPosLeft));
                canDodge = false;
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
            boostTimer -= Time.unscaledDeltaTime;
            if (boostTimer < 0)
            {
                boostTimer = .6f;
                canBoost = true;
            }
        }


    }

    IEnumerator Dodge(Vector3 Start, Vector3 End)
    {
        boostCheck();
        canBoost = false;
        boostTimer = boostTimerDefault;

        float lrp;
        while (dodgeTime < dodgeTimeDefault)
        {
            dodgeTime += Time.deltaTime;
            perc = dodgeTime / dodgeTimeDefault;

            lrp = Mathf.Lerp(Start.x, End.x, perc);
            rb.transform.position = new Vector3(lrp, rb.transform.position.y, rb.transform.position.z);


            yield return null;
        }
        dodgeDelay = dodgeDelayDefault;
        dodgeTime = 0;
        rb.AddForce(transform.forward * playerMovement.baseForwardSpeed *3, ForceMode.Impulse);
        yield return null;
    }

    //void dodgeRight()
    //{
    //
    //    boostCheck();
    //    canBoost = false;
    //    boostTimer = boostTimerDefault;
    //
    //    dodgeTime += Time.unscaledDeltaTime;
    //    perc = dodgeTime / lerpTime;
    //
    //    rb.transform.position = Vector3.Lerp(startPos, endPosRight, perc);
    //
    //    if (dodgeTime >= dodgeTimeDefault)
    //    {
    //        dodgeDelay = dodgeDelayDefault;
    //        dodgeTime = 0;
    //    }
    //
    //}
    //
    //void dodgeLeft()
    //{
    //    boostCheck();
    //    canBoost = false;
    //    boostTimer = boostTimerDefault;
    //
    //    dodgeTime += Time.deltaTime;
    //    perc = dodgeTime / lerpTime;
    //
    //    rb.transform.position = Vector3.Lerp(startPos, endPosLeft, perc);
    //
    //    if (dodgeTime >= dodgeTimeDefault)
    //    {
    //        dodgeDelay = dodgeDelayDefault;
    //        dodgeTime = 0;
    //        canDodge = false;
    //    }
    //
    //}
    //
    void boostCheck()
    {
        if (canBoost == true)
        {
            RaycastHit hit;         

            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, raycastRange))
            {
                //Debug.Log(hit.distance);
                
                dodgeRender.DodgeRender(hit, rayStart.position);

                playerScore.ScoreCalculate(hit.distance);

                playerMovement.baseMaxSpeed = playerMovement.baseMaxSpeed + (10 - (hit.distance / 5));
                playerMovement.maxSpeed = playerMovement.maxSpeed + (20 - ((hit.distance * 2) / 5));
               
                TimeManager.setSlowMotion();
            }

        }

    }


}
