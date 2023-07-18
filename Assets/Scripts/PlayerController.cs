using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private float timeSinceLastIncrease;
    public float initialSpeed = 5f; // The initial speed of the player
    public float maxSpeed = 10f;    // The maximum allowed speed for the player
    public float speedIncrement = 1f; // The amount to increase speed per second

    private int desiredLane = 1; //0: Left Lane, 1: Middle Lane, 2: Right Lane
    public float laneDistance = 2.5f; //Distance between two lanes 

    public float jumpForce;
    public float gravity = 20;

    public Animator anim;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        forwardSpeed = initialSpeed;
        timeSinceLastIncrease = 0f;
    }

    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        // Increment the time counter
        timeSinceLastIncrease += Time.deltaTime;

        // If enough time has passed, increase the player speed
        if (timeSinceLastIncrease >= 1f)
        {
            forwardSpeed += speedIncrement;
            Debug.Log(forwardSpeed);

            // Cap the player speed at the maximum allowed speed
            forwardSpeed = Mathf.Min(forwardSpeed, maxSpeed);

            // Reset the time counter
            timeSinceLastIncrease = 0f;
        }

        anim.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;


        if (SwipeManager.swipeUp && controller.isGrounded)
        {
            Jump();
            anim.SetBool("Grounded", false);
        }
        else if (controller.isGrounded == false)
        {
            direction.y -= gravity * Time.deltaTime;
            anim.SetBool("Grounded", true);
        }
        //Gather the inputs on which lane we should be

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)

            {
                desiredLane = 0;
            }
        }

        if (SwipeManager.swipeDown && controller.isGrounded)
        {
            Slide();
            anim.SetTrigger("Slide");
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            controller.height = 2.8f;
            controller.center = new Vector3(controller.center.x, 1.7f, controller.center.z);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            controller.height = 0.7f;
            controller.center = new Vector3(controller.center.x, 0.65f, controller.center.z);
            anim.SetBool("Slide", false);
        }

    }
        
    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        controller.Move(direction * Time.fixedDeltaTime);

        //Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }


    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
    
    private void Slide()
    {
        controller.height = 0.7f;
        controller.center = new Vector3(controller.center.x, 0.65f, controller.center.z);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            Destroy(hit.gameObject);
            anim.SetTrigger("GetHit");
        }
    }
}
 