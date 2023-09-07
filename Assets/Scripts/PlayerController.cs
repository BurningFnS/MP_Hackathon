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
    public float maxSpeed = 25f;    // The maximum allowed speed for the player
    public float speedIncrement = 1f; // The amount to increase speed per second

    //Lane-related variables
    private int desiredLane = 1; //0: Left Lane, 1: Middle Lane, 2: Right Lane
    public float laneDistance = 2.5f; //Distance between two lanes 

    //Jumping and gravity based variables
    public float jumpForce;
    public float gravity = 20;
    public bool hitObstacle = false;

    //Variables related to animator and particleSystems
    public Animator anim;
    public GameObject coinParticles;
    public GameObject explosionParticles;
    public GameObject smokeParticles;
    private ParticleSystem smokeBurst;
    private ParticleSystem coinBurst;
    private ParticleSystem explosionBurst;
    public GameObject magneticEffect;

    //Magnet PowerUp variables
    public float magnetDuration = 8f; // The duration of the magnet effect in seconds
    private bool magnetEffectActive = false;
    private float magnetRemainingTime = 0f;
    private float magnetRadius;

    //Shield PowerUp variables
    private bool shieldEffectActive = false;
    private float shieldRemainingTime = 0f;
    public GameObject shieldBarrier;

    //Variables to check if player is grounded
    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private bool isRolling = false;


    void Start()
    {
        //Initialize references
        smokeBurst = smokeParticles.GetComponent<ParticleSystem>();
        explosionBurst = explosionParticles.GetComponent<ParticleSystem>();
        coinBurst = coinParticles.GetComponent<ParticleSystem>();
        controller = GetComponent<CharacterController>();
        //set speed of player to default speed
        forwardSpeed = initialSpeed;
        timeSinceLastIncrease = 0f;
        TimeManager.isPaused = false;
    }

    void Update()
    {
        //Checks if game has not started
        if (!PlayerManager.isGameStarted)
            return;

        //Checks if game is paused
        if (TimeManager.isPaused)
            return;

        //if the player does not hit an obstacle, we want to increase player's speed
        if (hitObstacle == false)
        {
            // Increment the time counter
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
        //Set animation boolean of "isGameStarted" to true and change player's animation from idle to run
        anim.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;

        //Checks if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        anim.SetBool("Grounded", isGrounded);

        //if the player is on the ground and does not hit an obstacle and a swipe up is detected, jump
        if (isGrounded && hitObstacle == false)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }

        //if the player is not grounded and is rolling
        if (!isGrounded && isRolling == true)
        {
            //Send the player back to the ground and roll
            direction.y -= gravity * Time.deltaTime * 10;
        }
        //if the player is not on the ground
        else 
        {
            //Apply gravity
            direction.y -= gravity * Time.deltaTime;
        }

        if (hitObstacle == false)
        {
            //Gather the inputs on which lane we should be

            //Player can swipe right as long as they do not hit an obstacle and are not sliding
            if (SwipeManager.swipeRight)
            {
                desiredLane++;
                anim.SetTrigger("Right");

                //stop them from swiping right while on the right lane
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                }
            }

            //Player can swipe left as long as they do not hit an obstacle and are not sliding
            if (SwipeManager.swipeLeft)
            {
                desiredLane--;
                anim.SetTrigger("Left");

                //stop them from swiping left while on the left lane
                if (desiredLane == -1)
                {
                    desiredLane = 0;
                }
            }
            //If a swipe down is detected, roll
            if (SwipeManager.swipeDown)
            {
                Roll();
            }
        }


        //Animation check code

        //Checks if the player's animation is currently running and set their height and collider size
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            controller.height = 2.8f;
            controller.center = new Vector3(controller.center.x, 1.7f, controller.center.z);

            isRolling = false;
        }

        //Checks if the player's animation is currently tripping and make sure the animation plays only once
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Trip"))
        {
            anim.SetBool("GetHit", false);
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                hitObstacle = false;
            } 
        }

        //Checks if the player's animation is currently rolling and set their height and collider size
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Rolling"))
        {
            anim.SetBool("Roll", false);

            controller.height = 0.7f;
            controller.center = new Vector3(controller.center.x, 0.65f, controller.center.z);
        }


        //Magnet and Shield Code
        if (magnetEffectActive)
        {
            // Update magnet remaining time and disable magnet effect if time is up
            magnetRemainingTime -= Time.deltaTime;
            if (magnetRemainingTime <= 0f)
            {
                DisableMagnetEffect();
            }

            // Detect collectible items within the magnet radius and attract them towards the player
            Collider[] collectibles = Physics.OverlapSphere(transform.position, magnetRadius, LayerMask.GetMask("Collectible"));

            foreach (Collider collectible in collectibles)
            {
                //Adjust collectibles' position
                Vector3 coinPosition = collectible.transform.position;
                coinPosition.y = 1f; // Replace 'fixedYPosition' with the desired value
                collectible.transform.position = coinPosition;

                // Calculate the direction from the collectible to the player
                Vector3 direction = (transform.position - collectible.transform.position).normalized;

                // Move the collectible towards the player based on the distance and desired attraction speed
                float attractionSpeed = 40f; // Adjust as needed
                collectible.transform.position += direction * attractionSpeed * Time.deltaTime;
            }
        }

        if (shieldEffectActive)
        {
            // Update shield remaining time and disable magnet effect if time is up
            shieldRemainingTime -= Time.deltaTime;
            if (shieldRemainingTime <= 0f)
            {
                DisableShieldEffect();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;

        controller.Move(direction * Time.fixedDeltaTime);

        //Calculate the target position based on the desired lane

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

        //Move the player left/right towards the target position
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

    //Handle player jumping
    private void Jump()
    {
        isRolling = false; //can't roll
        direction.y = jumpForce;// Adjust player's y position to jumpForce
    }

    //Handle player rolling
    private void Roll()
    {
        isRolling = true; //Set rolling boolean to true
        anim.SetBool("Roll", true); //Play rolling animation through "roll" boolean
        //Adjust height and size of player's collider
        controller.height = 0.7f; 
        controller.center = new Vector3(controller.center.x, 0.65f, controller.center.z);
    }

    public void EnableMagnetEffect(float radius)
    {
        FindObjectOfType<Audio>().PlaysSound("Yay");//Play sound effect
        magnetEffectActive = true; //Set magnetactive boolean to true
        magneticEffect.SetActive(true); //Enable the magnetic effect in the scene on the player
        magnetRemainingTime = magnetDuration; //Set remaining duration of magnet
        magnetRadius = radius;//sets radius of magnet power-up
    }

    private void DisableMagnetEffect()
    {
        //Disables the boolean and the magnetic effect
        magnetEffectActive = false;
        magneticEffect.SetActive(false);
        // Perform any additional actions when the magnet effect ends, if needed.
    }

    //Get remaining magnet effect duration
    public float GetMagnetRemainingTime()
    {
        return magnetRemainingTime;
    }

    //Enables the shield effect
    public void EnableShieldEffect(float duration)
    {
        FindObjectOfType<Audio>().PlaysSound("Yay"); //Plays the sound effect
        shieldEffectActive = true; //Sets shieldActive boolean to true
        shieldBarrier.SetActive(true); //Enable the shield effect in the scene on the player
        shieldRemainingTime = duration;//Set remaining duration of shield
        // Activate the shield effect for the player, e.g., make the player invulnerable to obstacles
    }

    public void DisableShieldEffect()
    {
        //Disables the boolean and the shield effect
        shieldEffectActive = false;
        shieldBarrier.SetActive(false);
        // Deactivate the shield effect for the player, e.g., make the player vulnerable to obstacles again
    }

    // Get remaining shield effect duration
    public float GetShieldRemainingTime()
    {
        return shieldRemainingTime;
    }

    //This function handles the collision of player with obstacles, cars and trucks
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Plays the trip animation when colliding, plays the sound effect of a collision, plays coin explosion particle effect
        if (hit.transform.tag == "Obstacle")
        {
            hitObstacle = true;
            anim.SetTrigger("GetHit"); //Play the Trip animation

            Destroy(hit.gameObject); //Destroy the collided obstacle
            smokeBurst.Play(); //Plays smoke particle if colliding with obstacle
            CoinExplosion();

            FindObjectOfType<Audio>().PlaysSound("Bang");
        }

        if (hit.transform.tag == "Car" || hit.transform.tag == "Truck")
        {
            hitObstacle = true;
            anim.SetTrigger("GetHit"); //Play the Trip animation

            Destroy(hit.gameObject); //Destroy the collided obstacle
            explosionBurst.Play(); //Plays explosion particle if colliding with car or truck
            CoinExplosion();

            FindObjectOfType<Audio>().PlaysSound("Bang");
        }
    }

    private void CoinExplosion()
    {
        //Randomizes the amount of coins in the coin explosion particle effect depending on the amount of coins they have
        ParticleSystem.Burst[] bursts = new ParticleSystem.Burst[1];
        int randomNumber = Random.Range(1, 3);
        bursts[0].count = randomNumber;
        coinBurst.emission.SetBursts(bursts);

        coinBurst.Play(); // Play coin burst particle

        PlayerManager.numberOfCoins -= randomNumber; //Deduct a random amount of coins
        forwardSpeed = 5f;
    }
}
 