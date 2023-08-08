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

    private void Start()
    {
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
            visitUIPanel[receivedValue].SetActive(true);
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

