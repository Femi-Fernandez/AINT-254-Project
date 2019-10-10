using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject objectToFollow;
    public float speed = 2.0f;
   Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - objectToFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
            Vector3 desiredPosition = objectToFollow.transform.position + offset;
            transform.position = desiredPosition;
        }

    }
}
