using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float speed = 30f; //Speed of the car

    void Update()
    {
        //Return and do nothing if game hasn't started
        if (!PlayerManager.isGameStarted)
            return;

        //Move the car forawrd by taking in its speed and the currrent time in frames
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //This method is called when a collision with another object is detected
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the object that the car has collided with is a obstacle or truck and if they are, destroy the collided objects
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Truck")
        {
            Destroy(collision.gameObject);
        }
    }
}