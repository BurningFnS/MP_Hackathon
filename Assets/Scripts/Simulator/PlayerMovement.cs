using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        if (agent != null)
        {
            animator.SetBool("isRunning", true);
            Debug.Log(targetPosition);
            agent.SetDestination(targetPosition);
        }
        // Check if the player has reached the target within the stopping distance
        //if (agent.remainingDistance <= agent.stoppingDistance)
        //{
        //    animator.SetBool("isRunning", false);

        //    // Perform actions when the player reaches the target
        //    Debug.Log("Player has reached the target!");
        //}
    }

    private void Update()
    {

    }
}


