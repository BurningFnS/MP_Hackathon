using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    public float flySpeed = 4.0f; // Speed at which the text flies upwards
    public float destroyTime = 1f; // Time after which the text effect is destroyed

    public Text textComponent; //+10 second Text
    private GameObject target; //clock UI position

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("toClock");
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, flySpeed * Time.deltaTime);
    }

    public void SetText(string message)
    {
        textComponent.text = message;
    }
}
