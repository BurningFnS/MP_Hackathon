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
        //Finds the game object with the "toClock" tag
        target = GameObject.FindGameObjectWithTag("toClock");
        Destroy(gameObject, destroyTime); //Destroys the text object after destroyTime amount of seconds
    }

    private void Update()
    {
        //Creates a smooth transition from object's initial position to it's target position
        transform.position = Vector3.Lerp(transform.position, target.transform.position, flySpeed * Time.deltaTime);
    }

    public void SetText(string message)
    {
        //Sets the text inside the textComponent
        textComponent.text = message;
    }
}
