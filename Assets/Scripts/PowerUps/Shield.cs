using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float shieldDuration = 8f; // The duration of the shield effect in seconds
    public float bounceHeight = 1f;    // The maximum height the power-up will reach during each bounce

    private Vector3 startingPosition;    // Initial position of the power-up

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        //Use PingPong function to make a bouncing effect
        float verticalMovement = Mathf.PingPong(Time.time, bounceHeight);

        // Calculate the target position for the power-up
        Vector3 targetPosition = startingPosition + Vector3.up * verticalMovement;

        // Update the position of the power-up
        transform.position = targetPosition;
        // Update the position of the power-up
        transform.position = targetPosition;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply the shield power-up effect to the player
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.EnableShieldEffect(shieldDuration);
            }

            // Destroy the shield power-up GameObject after the player collects it
            Destroy(gameObject);
        }
    }
}
