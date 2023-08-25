using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] easyTilePrefabs;
    public GameObject[] intermediateTilePrefabs;
    public GameObject[] hardTilePrefabs;
    private GameObject[] ChosenTile;

    public float zSpawn = 0;
    public float tileLength = 45f;
    public int numberOfTiles = 3;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

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
                SpawnTile(Random.Range(1, ChosenTile.Length)); //Subsequent tiles that spawn will be random       
            }
        }
    }

    void Update()
    {
        if(playerTransform.position.z - 30 > zSpawn - (numberOfTiles * tileLength))
        {
   /*         if(Random.Range(0, 11) >= 8)
            {

            }*/
            SpawnTile(Random.Range(1, ChosenTile.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        //25 to 40 easy mode
        if (PlayerPrefs.GetInt("CurrentAge") >= 25 && PlayerPrefs.GetInt("CurrentAge") <= 40)
        {
            Debug.Log("Easy");
            ChosenTile = easyTilePrefabs;
        }
        // 45 to 65 intermediate mode
        else if (PlayerPrefs.GetInt("CurrentAge") >= 45 && PlayerPrefs.GetInt("CurrentAge") <= 65)
        {
            Debug.Log("Intermediate");
            ChosenTile = intermediateTilePrefabs;
        }
        else  //70 to 90 hard mode
        {
            Debug.Log("Hard");
            ChosenTile = hardTilePrefabs;
        }
        GameObject go = Instantiate(ChosenTile[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
