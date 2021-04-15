using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    public float slowDownVal = 0.05f;
    public float slowdownLength = 2f;
    public bool i = true;

    private void Start()
    {
        //
        
    }

    public void setSlowMotion()
    {
        Time.timeScale = slowDownVal;
        


    }
    private void FixedUpdate()
    {
        if (i)
        {
            Time.timeScale = slowDownVal;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            i = false;
        }
        Time.timeScale += (1 / slowdownLength) * Time.unscaledDeltaTime;
        

        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
}
