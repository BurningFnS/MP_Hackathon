using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] easyTilePrefabs; //Prefabs for easy tiles
    public GameObject[] intermediateTilePrefabs; //Prefabs for intermediate tiles
    public GameObject[] hardTilePrefabs;//Prefabs for hard tiles

    private GameObject[] ChosenTile; //Array of the chosen tiles based off of player's age
    public PlayerController playerController;

    public float zSpawn = 0; //z-position to spawn tiles
    public float tileLength = 45f; //Length of each tile
    public int numberOfTiles = 5; //number of tiles that initially spawn
    private List<GameObject> activeTiles = new List<GameObject>(); //List holding all the current active tiles
    public Transform playerTransform; //Gets the player's position

    private int previousNumber; //Previous index of the tile

    void Start()
    { 
        for (int i = 0; i < numberOfTiles; i++)
        {
            if(i == 0)
            {
                SpawnTile(0); //Making sure the first tile is always index 0
            }
            else
            {
                SpawnTile(GenerateRandomNumbers()); //Subsequent tiles that spawn will be random       
            }
        }
    }

    void Update()
    {
        //Once the player gets far enough away, spawn in more randomly generated tiles and delete all the tiles behind the player
        if(playerTransform.position.z - 25 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(GenerateRandomNumbers());
            DeleteTile();
        }
    }

    //Randomize a index for the tile generation
    private int GenerateRandomNumbers()
    {
        int randomNumber = Random.Range(1, ChosenTile.Length); // Adjust the range as needed
        //Make sure 2 adjacent tiles can't be the same tile index
        while (randomNumber == previousNumber)
        {
            randomNumber = Random.Range(1, ChosenTile.Length);
        }
        previousNumber = randomNumber;

        return randomNumber;
    }

    public void SpawnTile(int tileIndex)
    {
        //Based off of the age of the player, it will respectively spawn in the designated tile difficulty and change the maximum speed of the player
        //25 to 40: easy mode
        if (PlayerPrefs.GetInt("CurrentAge") >= 25 && PlayerPrefs.GetInt("CurrentAge") <= 40)
        {
            ChosenTile = easyTilePrefabs;
            playerController.maxSpeed = 25;
        }
        // 45 to 65: intermediate mode
        else if (PlayerPrefs.GetInt("CurrentAge") >= 45 && PlayerPrefs.GetInt("CurrentAge") <= 65)
        {
            ChosenTile = intermediateTilePrefabs;
            playerController.maxSpeed = 35;
        }
        else  //70 to 90: hard mode
        {
            ChosenTile = hardTilePrefabs;
            playerController.maxSpeed = 45;
        }
        GameObject go = Instantiate(ChosenTile[tileIndex], transform.forward * zSpawn, transform.rotation); //Spawm the tile and the correct designated location
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        //Destroy the earliest active tile and remove it from the list
        Destroy(activeTiles[0]); 
        activeTiles.RemoveAt(0);
    }
}
