using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject[] optionUIPanels;
    public void OptionsClicked()
    {
        optionUIPanels[0].SetActive(true);

    }

    public void CloseOptionsPanel()
    {
        optionUIPanels[0].SetActive(false);

    }
}
