using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    //void Update()
    //{
    //    transform.Rotate(0, 0, 50 * Time.deltaTime);
    //}

    public float bounceHeight = 0.5f;    // The maximum height the power-up will reach during each bounce

    private Vector3 startingPosition;    // Initial position of the power-up


    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        float verticalMovement = Mathf.PingPong(Time.time, bounceHeight);
        
        // Calculate the target position for the power-up
        Vector3 targetPosition = startingPosition + new Vector3(0,0.5f,0) * verticalMovement;

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