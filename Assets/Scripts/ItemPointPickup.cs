using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPointPickup : MonoBehaviour
{
    public GameObject player;

    public int pointValue = 50;
    // Start is called before the first frame update
    void Start()
    {
        //playerScore = gameObject.GetComponent<PlayerScore>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           
            player.GetComponent<PlayerScore>().pointPickup(pointValue);
            Destroy(gameObject);
            Debug.Log("here");
        }
    }
}
