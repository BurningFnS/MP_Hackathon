using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

    public float bounceHeight = 1.0f;    // The maximum height the power-up will reach during each bounce
    public float bounceSpeed = 1.0f;     // The speed at which the power-up will move up and down

    private Vector3 startingPosition;    // Initial position of the power-up
    private float groundOffset = 0.5f;   // Offset to prevent the object from going below the ground

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        float verticalMovement = Mathf.PingPong(Time.time * bounceSpeed, bounceHeight);
        
        // Calculate the target position for the power-up
        Vector3 targetPosition = startingPosition + Vector3.up * verticalMovement;

        // Check if the target position is below the ground level
        float groundLevel = 1f; // Replace this value with the actual ground level in your scene
        if (targetPosition.y < groundLevel + groundOffset)
        {
            targetPosition.y = groundLevel + groundOffset;
        }

        // Update the position of the power-up
        transform.position = targetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            TimeManager.timer += 10;
        }
    }
}