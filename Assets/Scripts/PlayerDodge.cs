using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    public float dodgeDelay;
    float dodgeDelayDefault = 1.0f;

    public float dodgeTime;
    float dodgeTimeDefault = 0.1f;
    bool canDodge = true;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }


    void dodgeRight()
    {
        dodgeTime -= Time.deltaTime;
        transform.Translate(new Vector3(1, 0, 0));
        if (dodgeTime <= 0)
        {
            dodgeDelay = dodgeDelayDefault;
            dodgeTime = dodgeTimeDefault;
            canDodge = false;
        }
    }

    void dodgeLeft()
    {
        dodgeTime -= Time.deltaTime;
        transform.Translate(new Vector3(-1, 0, 0));
        if (dodgeTime <= 0)
        {
            dodgeDelay = dodgeDelayDefault;
            dodgeTime = dodgeTimeDefault;
            canDodge = false;
        }
    }

}
