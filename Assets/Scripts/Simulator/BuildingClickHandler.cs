using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingClickHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] buildingUIPanels;
    public PlayerMovement playerMovement;
    public Transform[] buildingTransforms;
    public static bool canClickOnBuildings = true;

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
        if (canClickOnBuildings)
        {
            // Check if the clicked building has an associated UI panel
            int buildingIndex = GetBuildingIndex();
            if (buildingIndex >= 0 && buildingIndex < buildingUIPanels.Length)
            {
                // Activate the appropriate UI panel
                buildingUIPanels[buildingIndex].SetActive(true);
                for (int i = 0; i < buildingUIPanels.Length; i++)
                {
                    if (i != buildingIndex)
                    {
                        buildingUIPanels[i].SetActive(false);
                    }
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
    int GetVisitButtonIndex()
    {
        // Implement your own logic to determine which building is clicked.
        // You can use raycasting, tags, or other methods to identify the clicked building.
        // For simplicity, we'll just return a unique index for each building in this example.
        if (gameObject.name == "InvestmentVisitButton")
            return 0;
        else if (gameObject.name == "BankVisitButton")
            return 1;
        else if (gameObject.name == "JobVisitButton")
            return 2;
        else if (gameObject.name == "InsuranceVisitButton")
            return 3;
        else if (gameObject.name == "PropertyVisitButton")
            return 4;

        return -1;
    }

    public void Close()
    {
        foreach (GameObject panel in buildingUIPanels)
        {
            panel.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int visitButtonIndex = GetVisitButtonIndex();
        playerMovement.ReceiveButtonValue(visitButtonIndex);

        if (visitButtonIndex >= 0 && visitButtonIndex < buildingTransforms.Length)
        {
            buildingUIPanels[visitButtonIndex].SetActive(false);
            playerMovement.MoveToDestination(buildingTransforms[visitButtonIndex].position);
        }
    }
}
