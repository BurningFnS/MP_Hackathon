using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour
{
    public Material[] material;//Array of different materials to be used for different textures/outfits for the player
    Renderer shirtRenderer;//Reference to the renderer component of the object
    // Start is called before the first frame update
    void Update()
    {
        shirtRenderer = GetComponent<Renderer>(); 
        shirtRenderer.enabled = true;//Makes sure the renderer is enabled


        shirtRenderer.sharedMaterial = material[0];

        //Depending on the job of the player, this will change the texture of the player to match it's occupation
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

        //If the player retires, change to this texture 
        if (PlayerPrefs.GetInt("JobIndex") == 3)
        {
            shirtRenderer.sharedMaterial = material[3];
        }
        if(PlayerPrefs.GetInt("JobIndex")== 0 && PlayerPrefs.GetInt("Retirement") ==1 )
        {
            shirtRenderer.sharedMaterial = material[3];
        }
    }
    
}