using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime * 2); //Rotates the coin on it's z-axis to give a spinning effect
    }

    //This method is called when a trigger collision with another collider is detected
    private void OnTriggerEnter(Collider other)
    {
        //Check if the collided object has the "Player" tag
        if (other.tag == "Player")
        {
            FindObjectOfType<Audio>().PlaysSound("Coin"); //Play the 'Pick-Up Coin' audio clip
            PlayerManager.numberOfCoins += 2; //Increase number of coins collected by 2
            Destroy(gameObject); //Destroy the coin on pick up
        }
    }
}
