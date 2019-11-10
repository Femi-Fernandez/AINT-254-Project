using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeRender : MonoBehaviour
{

    private LineRenderer laserLine;
    private WaitForSeconds shotDuration = new WaitForSeconds(.05f);
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DodgeRender(RaycastHit hit, Vector3 rayStart)
    {
        StartCoroutine(ShotEffect());

        laserLine.SetPosition(0, rayStart);
        laserLine.SetPosition(1, hit.point);
    }
    private IEnumerator ShotEffect()
    {

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}
