using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    public float horizontalSpeed = 1.0f;
    public float forwardSpeed = 400.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rb.AddForce(transform.right * horizontalSpeed, ForceMode.Impulse);
            transform.position += (transform.right * horizontalSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // rb.AddForce(-transform.right * horizontalSpeed, ForceMode.Impulse);
            transform.position += (-transform.right * horizontalSpeed) * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.forward * forwardSpeed, ForceMode.Acceleration);
        }
  

    }
}
