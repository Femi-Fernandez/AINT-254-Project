using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFOVControl : MonoBehaviour
{
    Camera cam;
    public float FOVIncTime;
    float currentFOVIncTime;

    public float FOVDecTime;
    float currentFOVDecTime;

    float currentFOV;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }


    public void boostFOV()
    {

        StartCoroutine(FOVChange());

    }

    IEnumerator FOVChange()
    {
        currentFOVIncTime = 0;
        currentFOV = cam.fieldOfView;
        while (currentFOVIncTime < FOVIncTime)
        {
            currentFOVIncTime += Time.fixedDeltaTime;
            cam.fieldOfView = Mathf.SmoothStep(currentFOV, 100, currentFOVIncTime / FOVIncTime);
            yield return null;
        }
        currentFOVDecTime = 0;
        while (currentFOVDecTime < FOVDecTime)
        {
            currentFOVDecTime += Time.fixedDeltaTime;
            cam.fieldOfView = Mathf.Lerp(100, 60, currentFOVDecTime / FOVDecTime);
            yield return null;
        }



        yield return null;
    }

}
