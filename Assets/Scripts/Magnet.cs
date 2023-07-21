using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetRadius = 10f; // The radius within which collectible items are attracted

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply the magnet power-up effect to the player (e.g., enable magnet mode)
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.EnableMagnetEffect(magnetRadius);
            }

            // Destroy the magnet power-up GameObject after the player collects it
            Destroy(gameObject);
        }
    }
}
