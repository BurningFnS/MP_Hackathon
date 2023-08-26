using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    private float speed = 25f;

    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Truck")
        {
            Destroy(collision.gameObject);
        }
    }*/
}