using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public PlayerController playerController;

    void Update()
    {
        transform.Rotate(Vector3.up * 80 * Time.deltaTime);
        if (playerController.hitObstacle)
        {
            playerController.DisableShieldEffect();
        }
    }
}
