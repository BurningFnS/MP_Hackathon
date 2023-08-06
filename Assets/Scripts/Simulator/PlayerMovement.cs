using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] waypoints; // Assign the waypoints in the Inspector
    public float moveSpeed = 5f;
    public float stoppingDistance = 5f; // The distance at which the player stops

    private int currentWaypointIndex = 0;
    private bool isMoving = false;
    public Animator animator;
    private Quaternion initialRotation; // Initial rotation of the player

    private void Start()
    {
      /*  if (waypoints.Length > 0)
        {
            MoveToWaypoint(currentWaypointIndex);
        }*/
        animator = GetComponent<Animator>();
        initialRotation = transform.rotation; // Store the initial rotation

    }

    private void Update()
    {
        if (!isMoving || waypoints.Length == 0)
            return;

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;

        // Calculate the move direction
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        moveDirection.y = 0; // Ignore the Y component

        // Move towards the target waypoint's position
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Check if the player has reached the current waypoint
        float distanceToWaypoint = Vector3.Distance(transform.position, targetPosition);
        if (distanceToWaypoint < stoppingDistance)
        {
            isMoving = false;
            animator.SetBool("isRunning", false);
        }

        transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, transform.rotation.eulerAngles.y, initialRotation.eulerAngles.z);
    }

    public void MoveToWaypoint(int index)
    {
        isMoving = true;
        animator.SetBool("isRunning", true);

        // Set the rotation to look towards the current waypoint
        transform.LookAt(waypoints[index]);
        transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, transform.rotation.eulerAngles.y, initialRotation.eulerAngles.z);

        // Optionally, perform any actions when reaching a new waypoint
    }
}
