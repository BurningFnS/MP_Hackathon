using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //Reference to the target that it should be following/the player
    private Vector3 offset; //Initial distance that should always be kept between the player and the camera

    void Start()
    {
        offset = transform.position - target.position; //Calculate the initial offset between the player and the camera
    }

    //After all other updates, calculate the new position of the camera and use Vector3.Lerp to smoothly move the camera from its previous position to its new position
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(offset.x + target.position.x, transform.position.y, offset.z + target.position.z + 3.5f);
        transform.position = Vector3.Lerp(transform.position, newPosition, 1f);
    }
}
