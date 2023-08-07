using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildingClickHandler : MonoBehaviour
{
    public GameObject[] buildingUIPanels;
    public PlayerMovement playerMovement;
    public Transform[] buildingTransforms;

    private int buildingIndex;
    [HideInInspector]
    public int selectedBuilding;
    private Vector3 targetPosition;

    public PlayerMovement playermovement;

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
        // Check if the clicked building has an associated UI panel
        buildingIndex = GetBuildingIndex();
        Debug.Log("Building index is :" + buildingIndex);

        if (buildingIndex >= 0 && buildingIndex < buildingUIPanels.Length)
        {
            // Activate the appropriate UI panel
            buildingUIPanels[buildingIndex].SetActive(true);
            selectedBuilding = buildingIndex;
            Debug.Log(selectedBuilding);
            for (int i = 0; i < buildingUIPanels.Length; i++)
            {
                if (i != buildingIndex)
                {
                    buildingUIPanels[i].SetActive(false);
                }
            }
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

    Vector3 GetBuildingPosition(int buildingIndex)
    {
        return buildingTransforms[buildingIndex].transform.position;
    }

    public void Close()
    {
        foreach (GameObject panel in buildingUIPanels)
        {
            panel.SetActive(false);
        }
    }

    public void Visit()
    {
        targetPosition = GetBuildingPosition(GetBuildingIndex());
        Debug.Log("In visit function: " + selectedBuilding);
        playermovement.MoveToPosition(targetPosition);
        Debug.Log(targetPosition);

    }
}
