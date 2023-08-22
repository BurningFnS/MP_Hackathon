using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour
{
    public Material[] material;
    Renderer shirtRenderer;
    // Start is called before the first frame update
    void Update()
    {
        shirtRenderer = GetComponent<Renderer>();
        shirtRenderer.enabled = true;
        shirtRenderer.sharedMaterial = material[0];
        if (PlayerPrefs.GetInt("JobIndex") == 0)
        {
            shirtRenderer.sharedMaterial = material[0];

        }
        if (PlayerPrefs.GetInt("JobIndex") == 1)
        {
            shirtRenderer.sharedMaterial = material[1];

        }
        if (PlayerPrefs.GetInt("JobIndex") == 2)
        {
            shirtRenderer.sharedMaterial = material[2];

        }
    }
    
}