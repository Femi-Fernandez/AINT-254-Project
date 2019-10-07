using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    public float horizontalSpeed = 8.0f;
    public float forwardSpeed = 20.0f;
    public float maxSpeed = 100.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.magnitude < maxSpeed)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += (transform.right * horizontalSpeed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += (-transform.right * horizontalSpeed) * Time.deltaTime;

            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(transform.forward * forwardSpeed, ForceMode.Acceleration);
            }
        }  
        



    }
}
