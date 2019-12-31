using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;

    private float spawnZ = 0.0f;
    private float tileLength = 12.0f;
    
    private int amnTileOnScreen = 7;
    private int lastPrefabIndex = 0;
   

    // Start is called before the first frame update
    private void Start()
    {
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnTileOnScreen; i++)
        {
            if (i < 3)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTransform.position.z  > (spawnZ - amnTileOnScreen * tileLength)) ;
        {
            SpawnTile();
          
        }
    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
       
    }
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);

        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
    

}
