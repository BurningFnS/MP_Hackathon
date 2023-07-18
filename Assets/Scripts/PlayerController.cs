using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1; //0: Left Lane, 1: Middle Lane, 2: Right Lane
    public float laneDistance = 2.5f; //Distance between two lanes 

    public float jumpForce;
    public float gravity = 20;

    public Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();   
        
    }

    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        anim.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;


        if (SwipeManager.swipeUp)
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

        if (SwipeManager.swipeDown)
        {
            Slide();
            anim.SetTrigger("Slide");
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

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            controller.height = 2.8f;
            //controller.center = new Vector3(controller.center.x,1.7f, controller.center.z);
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
 