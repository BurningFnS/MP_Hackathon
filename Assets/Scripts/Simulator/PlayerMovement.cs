using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private bool isMoving;
    private int receivedValue;
    public GameObject[] visitUIPanel;
    public Retirement retirement;

    private void Start()
    {
        Time.timeScale = 1;// Set the game's time scale to 1
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToDestination(Vector3 targetPosition)
    {
        isMoving = true;
        agent.SetDestination(targetPosition);// Set the destination for the NavMeshAgent
    }

    public void Update()
    {
        //Check if player has reached its destination
        if (agent.hasPath && agent.remainingDistance <= agent.stoppingDistance)
        {
            // If remaining distance is within stopping distance, transition to idle
            animator.SetBool("isRunning", false);
            agent.ResetPath();
            isMoving = false;

            //Make sure the player cannot get a job after they retire
            if(PlayerPrefs.GetInt("Retirement") == 1 && receivedValue == 2)
            {
                if(PlayerPrefs.GetInt("JobIndex")==0) 
                {
                    PlayerPrefs.SetInt("Salary", 200);// Set the salary for pension
                }
                Debug.Log(PlayerPrefs.GetInt("JobIndex"));
                Debug.Log(PlayerPrefs.GetInt("Salary"));
                retirement.forcedRetiredPanel.SetActive(true); //Show retirement panel
                BuildingClickHandler.canClickOnBuildings = false;// Disable building clicks
            }
            else
            {
                visitUIPanel[receivedValue].SetActive(true);// Show the visit UI panel
                BuildingClickHandler.canClickOnBuildings = false;// Disable building clicks
            }
        }

        if (!agent.hasPath && !isMoving)
        {
            animator.SetBool("isRunning", false);// Transition to idle animation if no destination and not moving
        }
        if (isMoving)
        {
            // Otherwise, transition to run animation
            animator.SetBool("isRunning", true);
        }
    }

    public void ReceiveButtonValue(int value)
    {
        receivedValue = value;//Receive a value from UI buttons
    }
}


