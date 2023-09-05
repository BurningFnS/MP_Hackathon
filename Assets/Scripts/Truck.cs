using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    private float speed = 25f;

    void Update()
    {
        //Do nothing if game hasn't started
        if (!PlayerManager.isGameStarted)
            return;

        //Move the truck at a constant rate
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

    //If the truck collides with anything with the tag "Obstacle" or "Truck", destroy the collided object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Truck")
        {
            Destroy(collision.gameObject);
        }
    }
}
