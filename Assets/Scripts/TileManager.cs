using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] easyTilePrefabs;
    public GameObject[] intermediateTilePrefabs;
    public GameObject[] hardTilePrefabs;

    private GameObject[] ChosenTile;
    public PlayerController playerController;

    public float zSpawn = 0;
    public float tileLength = 45f;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    private int previousNumber;

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
                SpawnTile(GenerateRandomNumbers()); //Subsequent tiles that spawn will be random       
            }
        }
    }

    void Update()
    {
        if(playerTransform.position.z - 25 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(GenerateRandomNumbers());
            DeleteTile();
        }
    }

    private int GenerateRandomNumbers()
    {
        int randomNumber = Random.Range(1, ChosenTile.Length); // Adjust the range as needed
        while (randomNumber == previousNumber)
        {
            randomNumber = Random.Range(1, ChosenTile.Length);
        }
        previousNumber = randomNumber;

        return randomNumber;
    }

    public void SpawnTile(int tileIndex)
    {
        //25 to 40 easy mode
        if (PlayerPrefs.GetInt("CurrentAge") >= 25 && PlayerPrefs.GetInt("CurrentAge") <= 40)
        {
            ChosenTile = easyTilePrefabs;
            playerController.maxSpeed = 25;
        }
        // 45 to 65 intermediate mode
        else if (PlayerPrefs.GetInt("CurrentAge") >= 45 && PlayerPrefs.GetInt("CurrentAge") <= 65)
        {
            ChosenTile = intermediateTilePrefabs;
            playerController.maxSpeed = 35;
        }
        else  //70 to 90 hard mode
        {
            ChosenTile = hardTilePrefabs;
            playerController.maxSpeed = 45;
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
