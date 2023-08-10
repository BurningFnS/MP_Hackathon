using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] clickedPanel;

    public void ReturnBack()
    {
        for (int i = 0; i < clickedPanel.Length; i++)
        {
            clickedPanel[i].SetActive(false);
        }
        BuildingClickHandler.canClickOnBuildings = true;
    }

}
