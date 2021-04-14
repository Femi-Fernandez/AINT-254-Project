using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    //public GameObject objectToFollow;
    public Transform target;
    public float smoothSpeed = .125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - objectToFollow.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
           
            Vector3 desiredPosition = target.position + offset;

                transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);


            //Vector3 desiredPosition = objectToFollow.transform.position + offset;
            //transform.position = desiredPosition;
        }

    }
}
