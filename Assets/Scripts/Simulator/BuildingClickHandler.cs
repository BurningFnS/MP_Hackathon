using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildingClickHandler : MonoBehaviour
{
    public GameObject[] buildingUIPanels;

    void Start()
    {
        // Disable all UI panels at the start
        foreach (GameObject panel in buildingUIPanels)
        {
            panel.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("HELLO");
        // Check if the clicked building has an associated UI panel
        int buildingIndex = GetBuildingIndex();
        Debug.Log(buildingIndex);

        if (buildingIndex >= 0 && buildingIndex < buildingUIPanels.Length)
        {
            // Activate the appropriate UI panel
            buildingUIPanels[buildingIndex].SetActive(true);
        }
    }

    int GetBuildingIndex()
    {
        // Implement your own logic to determine which building is clicked.
        // You can use raycasting, tags, or other methods to identify the clicked building.
        // For simplicity, we'll just return a unique index for each building in this example.
        if (gameObject.name == "Stock")
            return 0;
        else if (gameObject.name == "Bank")
            return 1;
        else if (gameObject.name == "Job")
            return 2;
        else if (gameObject.name == "Insurance")
            return 3;
        else if (gameObject.name == "House")
            return 4;

        return -1;
    }
}
