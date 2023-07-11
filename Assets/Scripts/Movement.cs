using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isRunning = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isRunning)
            {
                isRunning = true;
                // Start the endless running animation or game logic here
            }
        }

        if (isRunning)
        {
            // Move the player forward
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Move the player left or right based on input
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        }
    }
}

