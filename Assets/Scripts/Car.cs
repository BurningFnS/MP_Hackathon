using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float speed = 10f;

    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
