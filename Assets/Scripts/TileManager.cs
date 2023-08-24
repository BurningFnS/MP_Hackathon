using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] easyTilePrefabs;
    public GameObject[] intermediateTilePrefabs;
    public GameObject[] hardTilePrefabs;

    public float zSpawn = 0;
    public float tileLength = 45f;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    public CoinManager coinManager;

    void Start()
    { 

        for (int i = 0; i < numberOfTiles; i++)
        {
            if(i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(1, easyTilePrefabs.Length)); //Subsequent tiles that spawn will be random       
            }
        }
    }

    void Update()
    {
        if(playerTransform.position.z - 55.5 > zSpawn - (numberOfTiles * tileLength))
        {
   /*         if(Random.Range(0, 11) >= 8)
            {

            }*/
            SpawnTile(Random.Range(1, easyTilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(easyTilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

/*    private int DifficultyMode()
    {
        //25 to 40 easy mode
        if (coinManager.currentAge >= 25 && coinManager.currentAge <= 40)
        {
            return 0;
        }
        //45 to 65 intermediate mode
        else if (coinManager.currentAge >= 45 && coinManager.currentAge <= 65)
        {
            return 1;
        }
        else  //65 to 90 hard mode
        {
            return 2; 
        }
    }*/
}
