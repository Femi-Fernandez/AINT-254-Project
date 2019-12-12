using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] chunkPrefabs;
    private List<GameObject> activeChunks;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float chunkLength = 302.91f;
    private float destroyBuffer = 332f;
    private int numCurrentTiles = 7;
    // Start is called before the first frame update
    void Start()
    {
        activeChunks = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < numCurrentTiles; i++)
        {       
            SpawnTile();
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform!= null)
        {
            if (playerTransform.position.z - destroyBuffer > (spawnZ - numCurrentTiles * chunkLength))
            {
                SpawnTile();
                DeleteTile();
            }
        }

        
    }
    private void DeleteTile()
    {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }

    public void SpawnTile(int prefabNum = -1)
    {
        GameObject tile;
        int stageum = Random.Range(0, 5);
        tile = Instantiate(chunkPrefabs[stageum]) as GameObject;
        tile.transform.SetParent(transform);
        tile.transform.position = Vector3.forward * spawnZ;
        spawnZ += chunkLength;
        activeChunks.Add(tile);
    }
}
