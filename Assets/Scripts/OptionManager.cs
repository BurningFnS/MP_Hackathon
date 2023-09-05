using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject[] optionUIPanels; 
    public void OptionsClicked()
    {
        //Show the options panel
        optionUIPanels[0].SetActive(true);
        
    }

    public void CloseOptionsPanel()
    {
        //Hide the options panel
        optionUIPanels[0].SetActive(false);

    }
}
