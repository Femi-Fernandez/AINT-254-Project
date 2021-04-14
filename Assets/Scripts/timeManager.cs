using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    public float slowDownVal = 0.05f;
    public float slowdownLength = 2f;

    private void Start()
    {
        Time.timeScale = slowDownVal;
    }
    public void setSlowMotion()
    {
        Time.timeScale = slowDownVal;
        Time.fixedDeltaTime = Time.timeScale * .02f;


    }
    private void FixedUpdate()
    {
        Time.timeScale += (1 / slowdownLength) * Time.unscaledDeltaTime;
        

        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
}
