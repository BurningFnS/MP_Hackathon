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
            FindObjectOfType<Audio>().PlaysSound("Yay");
            GameObject canvas = GameObject.Find("Canvas"); // Make sure your Canvas object is named "Canvas"
            GameObject textEffect = Instantiate(textEffectPrefab, canvas.transform);
            textEffect.GetComponent<TextEffect>().SetText("+" + 8 + "s");
            Destroy(gameObject);
            TimeManager.timer += 8;
        }
    }
}