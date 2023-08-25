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
        Time.timeScale = 1;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToDestination(Vector3 targetPosition)
    {
        isMoving = true;
        agent.SetDestination(targetPosition);
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
                if(PlayerPrefs.GetInt("JobIndex")==0) //to actually set the salary for the pension 
                {
                    PlayerPrefs.SetInt("Salary", 200);
                }
                Debug.Log(PlayerPrefs.GetInt("JobIndex"));
                Debug.Log(PlayerPrefs.GetInt("Salary"));
                retirement.forcedRetiredPanel.SetActive(true);
                BuildingClickHandler.canClickOnBuildings = false;
            }
            else
            {
                visitUIPanel[receivedValue].SetActive(true);
                BuildingClickHandler.canClickOnBuildings = false;
            }
        }

        if (!agent.hasPath && !isMoving)
        {
            animator.SetBool("isRunning", false);
        }
        if (isMoving)
        {
            // Otherwise, transition to run animation
            animator.SetBool("isRunning", true);
        }
    }

    public void ReceiveButtonValue(int value)
    {
        receivedValue = value;
    }
}

