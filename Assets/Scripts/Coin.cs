using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 17f;
    public static bool coinMove = false;

    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);

        if(coinMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
            Destroy(gameObject);
        }

        if (other.tag == "Coin Detector")
        {
            coinMove = true;
        }
    }
}
