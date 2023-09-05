using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public PlayerController playerController; //Reference to player controller

    void Update()
    {
        //Rotates the shield barrier on its y-axis
        transform.Rotate(Vector3.up * 80 * Time.deltaTime);
    }

    //If object has collided with any obstacles, cars or trucks, destroy the collided gameobject
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Car") || other.CompareTag("Truck"))
        {
            Destroy(other.gameObject);
        }
    }
}
