using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSelection : MonoBehaviour
{
    public GameObject[] jobPanels;
    private int currentPanelIndex = 0;

    public void LoadScene(string name)
    {

        SceneManager.LoadScene(name);
    }

    //----

    private void Start()
    {
        ShowPanel(currentPanelIndex);
    }

    public void ShowNextPanel()
    {
        currentPanelIndex = (currentPanelIndex + 1) % jobPanels.Length;
        ShowPanel(currentPanelIndex);
    }

    public void ShowPreviousPanel()
    {
        currentPanelIndex = (currentPanelIndex - 1 + jobPanels.Length) % jobPanels.Length;
        ShowPanel(currentPanelIndex);
    }

    private void ShowPanel(int index)
    {
        for (int i = 0; i < jobPanels.Length; i++)
        {
            jobPanels[i].SetActive(i == index);
        }
    }
}


