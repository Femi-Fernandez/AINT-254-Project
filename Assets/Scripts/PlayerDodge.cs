using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    Rigidbody rb;
    float dodgeDelay;
    float dodgeDelayDefault = .5f;

    float dodgeTime;
    float dodgeTimeDefault = 0.1f;
    bool canDodge = true;

    public float boostTimer;
    float boostTimerDefault = .5f;
    bool canBoost = true;

    float raycastRange = 50f;
    public float dodgeDistance = 150f;

    float moveDistance = 1f;

    Vector3 startPos;
    Vector3 endPos;

    public bool lerping = false;

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
        startPos = transform.position;
        endPos = transform.position + transform.right * moveDistance;

        if (canDodge == true)
        {
            //if(Input.GetKey(KeyCode.Space))
            //{
            //   if(Input.GetKeyDown(KeyCode.RightArrow))
            //    {
            //        endPos = transform.position + transform.right * moveDistance;
            //    }
            //    //transform.position = Vector3.Lerp(startPos, endPos, 0.5f);
            //}

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space) && !lerping)
            {
                dodgeRight();
                canDodge = false;
               //StartCoroutine("LerpPosition");

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

    //IEnumerator LerpPosition()
    //{
    //    Debug.Log("Calling coroutine!!!");
    //    Vector3 _endPos = transform.position + transform.right * moveDistance;
    //    lerping = true;
    //
    //    while (endPos != transform.position)
    //    {
    //        transform.position = Vector3.Lerp(transform.position, _endPos, 0.5f);
    //
    //        yield return null;
    //    }
    //
    //    lerping = false;
    //}

    void dodgeRight()
    {
        
        boostCheck();
        canBoost = false;
        boostTimer = boostTimerDefault;

        dodgeTime += Time.deltaTime;

        float perc = dodgeTime / dodgeTimeDefault;
        //perc = Mathf.Sin(perc * Mathf.PI * 0.25f);
        Debug.Log(perc);
        transform.position = Vector3.Lerp(startPos, endPos,1- perc);

        //rb.transform.position += (transform.right * dodgeDistance) *Time.deltaTime;
        //transform.Translate(new Vector3(1, 0, 0));

        if (dodgeTime >= dodgeTimeDefault)
        {
            dodgeDelay = dodgeDelayDefault;
            dodgeTime = 0;
            canDodge = false;     
        }
        
    }

    void dodgeLeft()
    {
        boostCheck();
        canBoost = false;
        boostTimer = boostTimerDefault;

        dodgeTime += Time.deltaTime;
        //transform.Translate(new Vector3(-1, 0, 0));
        rb.transform.position += (-transform.right * dodgeDistance) * Time.deltaTime;

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
                Debug.Log(hit.distance);
                

                PlayerMovement.baseMaxSpeed = PlayerMovement.baseMaxSpeed + (10 - (hit.distance / 5));
                PlayerMovement.maxSpeed = PlayerMovement.maxSpeed + (20 - ((hit.distance * 2) / 5));

            }

        }

    }

}
