using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingClickHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] buildingUIPanels; //References to all the panels that have to do with building UI
    public PlayerMovement playerMovement;
    public Transform[] buildingTransforms; //positions of all the buildings
    public static bool canClickOnBuildings = true; //Flag to check if player can click on building

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
        // Find out what building is being clicked and return the index
        if (gameObject.name == "Stock")
            return 0;
        else if (gameObject.name == "Bank")
            return 1;
        else if (gameObject.name == "Job")
            return 2;
        else if (gameObject.name == "Insurance")
            return 3;
        else if (gameObject.name == "Property")
            return 4;

        return -1;
    }
    int GetVisitButtonIndex()
    {
        // Find out which visit building button is being clicked and return the index
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
        // Close all building UI panels
        foreach (GameObject panel in buildingUIPanels)
        {
            panel.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int visitButtonIndex = GetVisitButtonIndex(); //Get the index of the building through the visit button
        playerMovement.ReceiveButtonValue(visitButtonIndex);//Pass the visit button value to the player movement script
        
        if (visitButtonIndex >= 0 && visitButtonIndex < buildingTransforms.Length)
        {
            //Hide the building panel and use nav mesh agent to move to the destination(transform of the building)
            buildingUIPanels[visitButtonIndex].SetActive(false);
            playerMovement.MoveToDestination(buildingTransforms[visitButtonIndex].position);
        }
    }
}
