using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour
{
    public Material[] material;
    Renderer renderer;
    // Start is called before the first frame update
    void Update()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        renderer.sharedMaterial = material[0];
        if (PlayerPrefs.GetInt("JobIndex") == 0)
        {
            renderer.sharedMaterial = material[0];

        }
        if (PlayerPrefs.GetInt("JobIndex") == 1)
        {
            renderer.sharedMaterial = material[1];

        }
        if (PlayerPrefs.GetInt("JobIndex") == 2)
        {
            renderer.sharedMaterial = material[2];

        }
    }
    
}