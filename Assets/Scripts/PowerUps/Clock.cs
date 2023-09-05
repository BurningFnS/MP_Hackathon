using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float bounceHeight = 0.5f;    // The maximum height the power-up will reach during each bounce

    private Vector3 startingPosition;    // Initial position of the power-up

    public GameObject textEffectPrefab; // Reference to the text effect prefab

    private void Start()
    {
        startingPosition = transform.position; //Store the starting position of the clock
    }

    private void Update()
    {
        //Use PingPong function to make a bouncing effect
        float verticalMovement = Mathf.PingPong(Time.time, bounceHeight);
        
        // Calculate the target position for the power-up
        Vector3 targetPosition = startingPosition + new Vector3(0,0.5f,0) * verticalMovement;

        // Update the position of the power-up
        transform.position = targetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if the power-up is colliding with player
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Audio>().PlaysSound("Yay"); //Plays the respective sound effect
            GameObject canvas = GameObject.Find("Canvas"); // Make sure your Canvas object is named "Canvas"
            //Instantiate a text effect prefab and set the text to display "+8s"
            GameObject textEffect = Instantiate(textEffectPrefab, canvas.transform);
            textEffect.GetComponent<TextEffect>().SetText("+" + 8 + "s");
            //Destroy the clock powerup
            Destroy(gameObject);
            //Add 8 seconds to the in game timer
            TimeManager.timer += 8;
        }
    }
}