using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] titlePrefabs;
    public GameObject[] railwayTitlePrefabs;

    public float zSpawn = 0f;
    public float tileLength = 30f;
    public int tileCount = 5;
    public int tileDeletionDelay;
    private List<GameObject> activeTiles = new List<GameObject>();

    public int lv1ProgressionValue;
    public int lv2ProgressionValue;

    public Transform player;
    private int CurrentLevel = 1;
    private int tileSpawn = 0;

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
            Debug.Log("SpawnNum " + tileSpawn);
            if(tileSpawn >= lv1ProgressionValue + tileCount) {CurrentLevel = 2;}
            if(tileSpawn >= lv2ProgressionValue + lv1ProgressionValue + tileCount) {CurrentLevel = 3;}

            switch(CurrentLevel)
            {
                case 1: SpawnMap(Random.Range(0, titlePrefabs.Length)); break;
                case 2: SpawnMap(Random.Range(0, railwayTitlePrefabs.Length)); break;
                //Loop first
                case 3: SpawnMap(Random.Range(0, titlePrefabs.Length)); break;
            }

            DeleteTile();
        }
    }

    public void SpawnMap(int _index)
    {   
        tileSpawn++;
        GameObject tile;

        switch(CurrentLevel)
        {
            case 1: tile = Instantiate(titlePrefabs[_index],transform.forward * zSpawn, transform.rotation); activeTiles.Add(tile); break;
            case 2: tile = Instantiate(railwayTitlePrefabs[_index],transform.forward * zSpawn, transform.rotation); activeTiles.Add(tile); break;
            //Loop first
            case 3: tile = Instantiate(titlePrefabs[_index],transform.forward * zSpawn, transform.rotation); activeTiles.Add(tile); break;
        }

        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
