using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraLoop : MonoBehaviour
{
    public float scrollSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,scrollSpeed);
        if (transform.position.x <= -8)
        {
            transform.position = new Vector3(24, 0.67f, 0);
        }
    }
}
