using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private float timeSinceLastIncrease;
    public float initialSpeed = 10f; // The initial speed of the player
    public float maxSpeed = 30f;    // The maximum allowed speed for the player
    public float speedIncrement = 2f; // The amount to increase speed per second

    private int desiredLane = 1; //0: Left Lane, 1: Middle Lane, 2: Right Lane
    public float laneDistance = 2.5f; //Distance between two lanes 

    public float jumpForce;
    public float gravity = 20;
    private bool hitObstacle = false;
    private float timeDelay;
    public Animator anim;
    public GameObject coinParticles;
    public GameObject explosionParticles;
    private ParticleSystem coinBurst;
    private ParticleSystem explosionBurst;

    public float magnetDuration = 8f; // The duration of the magnet effect in seconds
    private bool magnetEffectActive = false;
    private float magnetRemainingTime = 0f;
    private float magnetRadius;

    private bool shieldEffectActive = false;
    private float shieldRemainingTime = 0f;
    public GameObject shieldBarrier;

    void Start()
    {
        explosionBurst = explosionParticles.GetComponent<ParticleSystem>();
        coinBurst = coinParticles.GetComponent<ParticleSystem>();
        controller = GetComponent<CharacterController>();
        forwardSpeed = initialSpeed;
        timeSinceLastIncrease = 0f;
        timeDelay = 0f;
    }

    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        // Increment the time counter
        if (hitObstacle == false)
        {
            timeSinceLastIncrease += Time.deltaTime;

            // If enough time has passed, increase the player speed
            if (timeSinceLastIncrease >= 1f)
            {
                forwardSpeed += speedIncrement;

                // Cap the player speed at the maximum allowed speed
                forwardSpeed = Mathf.Min(forwardSpeed, maxSpeed);

                // Reset the time counter
                timeSinceLastIncrease = 0f;
            }
        }

        if (hitObstacle == true)
        {
            timeDelay += Time.deltaTime;

            if (timeDelay >= 1.8f)
            {
                hitObstacle = false;

                // Reset the time counter
                timeDelay = 0f;
            }
        }

        anim.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;


        if (SwipeManager.swipeUp && controller.isGrounded && hitObstacle == false)
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

        if (SwipeManager.swipeRight && hitObstacle == false)
        {

            desiredLane++;
            anim.SetTrigger("Right");
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft && hitObstacle == false)
        {
            desiredLane--;
            anim.SetTrigger("Left");
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        if (SwipeManager.swipeDown && controller.isGrounded && hitObstacle == false)
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
            Slide();
            anim.SetBool("Slide", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Trip"))
        {
            anim.SetBool("GetHit", false);
        }


        if (magnetEffectActive)
        {
            Debug.Log("Magnet Enabled");

            // Update magnet remaining time and disable magnet effect if time is up
            magnetRemainingTime -= Time.deltaTime;
            if (magnetRemainingTime <= 0f)
            {
                Debug.Log("Magnet Disabled");
                DisableMagnetEffect();
            }

            // Detect collectible items within the magnet radius and attract them towards the player
            Collider[] collectibles = Physics.OverlapSphere(transform.position, magnetRadius, LayerMask.GetMask("Collectible"));

            foreach (Collider collectible in collectibles)
            {
                Vector3 coinPosition = collectible.transform.position;
                coinPosition.y = 1f; // Replace 'fixedYPosition' with the desired value
                collectible.transform.position = coinPosition;

                // Calculate the direction from the collectible to the player
                Vector3 direction = (transform.position - collectible.transform.position).normalized;

                // Move the collectible towards the player based on the distance and desired attraction speed
                float attractionSpeed = 50f; // Adjust as needed
                collectible.transform.position += direction * attractionSpeed * Time.deltaTime;
            }
        }

        if (shieldEffectActive)
        {
            Debug.Log("Shield Enabled");
            shieldRemainingTime -= Time.deltaTime;
            if (shieldRemainingTime <= 0f)
            {
                Debug.Log("Shield Disabled");
                DisableShieldEffect();
            }
        }
    }
        
    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;

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

    public void EnableMagnetEffect(float radius)
    {
        magnetEffectActive = true;
        magnetRemainingTime = magnetDuration;
        magnetRadius = radius;
    }

    private void DisableMagnetEffect()
    {
        magnetEffectActive = false;
        // Perform any additional actions when the magnet effect ends, if needed.
    }

    public void EnableShieldEffect(float duration)
    {
        shieldEffectActive = true;
        shieldBarrier.SetActive(true);
        shieldRemainingTime = duration;
        // Activate the shield effect for the player, e.g., make the player invulnerable to obstacles
    }

    private void DisableShieldEffect()
    {
        shieldEffectActive = false;
        shieldBarrier.SetActive(false);
        // Deactivate the shield effect for the player, e.g., make the player vulnerable to obstacles again
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            Destroy(hit.gameObject); //Destroy the collided obstacle
            ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[1];
            int randomNumber = Random.Range(1, 3);
            bursts[0].count = randomNumber;
            coinBurst.emission.SetBursts(bursts);
            coinBurst.Play(); // Play coin burst particle

            PlayerManager.numberOfCoins -= randomNumber; //Deduct a random amount of coins
            anim.SetTrigger("GetHit"); //Play the Trip animation

            hitObstacle = true;
            forwardSpeed = initialSpeed;
        }

        if(hit.transform.tag == "Car")
        {
            explosionBurst.Play();
            Destroy(hit.gameObject); //Destroy the collided obstacle
            ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[1];
            int randomNumber = Random.Range(1, 3);
            bursts[0].count = randomNumber;
            coinBurst.emission.SetBursts(bursts);
            coinBurst.Play(); // Play coin burst particle

            PlayerManager.numberOfCoins -= randomNumber; //Deduct a random amount of coins
            anim.SetTrigger("GetHit"); //Play the Trip animation

            hitObstacle = true;
            forwardSpeed = initialSpeed;
        }
    }
}
 