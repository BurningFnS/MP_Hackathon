using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject StartTile;

    public Vector3 length;
    private MeshRenderer renderer;
    public Vector3 nextTile;
    public Vector3 differenceBetweenTile = new Vector3(0f,0f,0.434f);

    private void Start()
    {
        //renderer = GetComponent<MeshRenderer>();
        //length =  renderer.bounds.size;

        GameObject StartPlane0 = Instantiate(StartTile, transform);
        StartPlane0.transform.position = new Vector3(0, 0, -0.234f);
        nextTile = StartPlane0.transform.position;

        GameObject StartPlane1 = Instantiate(StartTile, transform);
        StartPlane1.transform.position = nextTile + differenceBetweenTile;
        nextTile = StartPlane1.transform.position;

        GameObject StartPlane2 = Instantiate(Tile2, transform);
        StartPlane2.transform.position = nextTile + differenceBetweenTile;
        nextTile = StartPlane2.transform.position;

        GameObject StartPlane3 = Instantiate(Tile1, transform);
        StartPlane3.transform.position = nextTile + differenceBetweenTile;
        nextTile = StartPlane3.transform.position;

        GameObject StartPlane4 = Instantiate(Tile2, transform);
        StartPlane4.transform.position = nextTile + differenceBetweenTile;
        nextTile = StartPlane4.transform.position;
    }

    /*private void Update()
    {
        gameObject.transform.position += new Vector3(4 * Time.deltaTime, 0, 0);

        if (transform.position.x >= Index)
        {
            int RandomInt1 = Random.Range(0, 2);

            if (RandomInt1 == 1)
            {
                GameObject TempTile1 = Instantiate(Tile1, transform);
                TempTile1.transform.position = new Vector3(-16, 0, 0);
            }
            else if (RandomInt1 == 0)
            {
                GameObject TempTile1 = Instantiate(Tile2, transform);
                TempTile1.transform.position = new Vector3(-16, 0, 0);
            }

            int RandomInt2 = Random.Range(0, 2);

            if (RandomInt2 == 1)
            {
                GameObject TempTile2 = Instantiate(Tile1, transform);
                TempTile2.transform.position = new Vector3(-24, 0, 0);
            }
            else if (RandomInt2 == 0)
            {
                GameObject TempTile2 = Instantiate(Tile2, transform);
                TempTile2.transform.position = new Vector3(-24, 0, 0);
            }

            Index = Index + 15.95f;
        }
    }*/
}
