using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float shieldDuration = 10f; // The duration of the shield effect in seconds

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
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
