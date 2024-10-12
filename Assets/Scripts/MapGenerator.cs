using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] titlePrefabs;
    public float zSpawn = 0f;
    public float tileLength = 30f;
    public int tileCount = 5;
    public int tileDeletionDelay;

    public Transform player;


    private List<GameObject> activeTiles = new List<GameObject>();

    private void Start()
    {
        for(int i = 0;i < tileCount; i++)
        {
            if(i == 0)
            {
                SpawnMap(0);
            }else
            {
                SpawnMap(Random.Range(0, titlePrefabs.Length));
            }
        }
    }

    private void Update() 
    {
        if(player.position.z - tileDeletionDelay  > zSpawn - (tileCount * tileLength))
        {
            SpawnMap(Random.Range(0, titlePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnMap(int _index)
    {        
        GameObject tile = Instantiate(titlePrefabs[_index],transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(tile);

        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
