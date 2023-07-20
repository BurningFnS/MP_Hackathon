using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject coinDetector;

    // Start is called before the first frame update
    void Start()
    {
        coinDetector = GameObject.FindGameObjectWithTag("Coin Detector");
        coinDetector.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
