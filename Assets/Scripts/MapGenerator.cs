using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject startTilePrefab;
    public GameObject[] titlePrefabs;
    public GameObject[] railwayTitlePrefabs;
    public GameObject[] oldVillageTitlePrefabs;
    public GameObject endTitlePrefab;

    public float zSpawn = 0f;
    public float tileLength = 30f;
    public int tileCount = 5;
    public int tileDeletionDelay;
    private List<GameObject> activeTiles = new List<GameObject>();

    public int lv1ProgressionValue;
    public int lv2ProgressionValue;
    public int lv3ProgressionValue;

    public Transform player;
    private int CurrentLevel = 0;
    private int tileSpawn = 0;

    private void Start()
    {
        for(int i = 0;i < tileCount; i++)
        {
            if(i == 0)
            {
                SpawnMap(0);
                CurrentLevel = 1;
                
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
            if(CurrentLevel == 5) return;

            // Debug.Log("SpawnNum " + tileSpawn);
            if(tileSpawn >= lv1ProgressionValue + tileCount) {CurrentLevel = 2;}
            if(tileSpawn >= lv2ProgressionValue + lv1ProgressionValue + tileCount) {CurrentLevel = 3;}
            if(tileSpawn >= lv3ProgressionValue + lv2ProgressionValue + lv1ProgressionValue + tileCount) {CurrentLevel = 4;}
            //end value

            if(CurrentLevel == 4)
            {
                Instantiate(endTitlePrefab,transform.forward * zSpawn, transform.rotation);
                CurrentLevel++;
                return;
            }
            

            switch(CurrentLevel)
            {
                case 1: SpawnMap(Random.Range(0, titlePrefabs.Length)); break;
                case 2: SpawnMap(Random.Range(0, railwayTitlePrefabs.Length)); break;
                case 3: SpawnMap(Random.Range(0, oldVillageTitlePrefabs.Length)); break;
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
            case 0: tile = Instantiate(startTilePrefab,transform.forward * zSpawn, transform.rotation); activeTiles.Add(tile); break;
            case 1: tile = Instantiate(titlePrefabs[_index],transform.forward * zSpawn, transform.rotation); activeTiles.Add(tile); break;
            case 2: tile = Instantiate(railwayTitlePrefabs[_index],transform.forward * zSpawn, transform.rotation); activeTiles.Add(tile); break;
            case 3: tile = Instantiate(oldVillageTitlePrefabs[_index],transform.forward * zSpawn, transform.rotation); activeTiles.Add(tile); break;
        }

        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
