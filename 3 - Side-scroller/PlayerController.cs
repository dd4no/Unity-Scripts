using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Objects
    private Rigidbody playerBody;
    private Animator playerAnimator;

    // Scripts
    private MoveLeft moveLeft;

    // Actions
    private float jumpForce = 800.0f;
    private float gravityModifier = 2.0f;

    // Particles
    public ParticleSystem explosion;
    public ParticleSystem dirt;

    // Audio
    private AudioSource soundEffects;
    private AudioSource music;
    public AudioClip jump;
    public AudioClip crash;

    // Flags
    public bool isOnGround = true;
    public bool gameOver = false;
    private bool hasExtraJump = true;
    public bool sprintMode = false;

    void Start()
    {
        // Load Player Objects and Audio
        playerBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        soundEffects = GetComponent<AudioSource>();
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        // Modify gravity
        Physics.gravity *= gravityModifier;

        // Get Script
        moveLeft = GameObject.Find("Background").GetComponent<MoveLeft>();

        dirt.Stop();
    }

    void Update()
    {
        // If Spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            // Player on Ground
            if (isOnGround)
            {
                hasExtraJump = true;
                Jump();
            }
            // Player off Ground
            else if (!isOnGround && hasExtraJump)
            {
                hasExtraJump = false;
                Jump();
            }
        }

        // If Left Alt button pressed
        if (Input.GetKey(KeyCode.LeftAlt) && !gameOver)
        {
            sprintMode = true;
            moveLeft.scrollSpeed = 40.0f;
            playerAnimator.SetFloat("Sprint_f", 2.0f);
        }
        else
        {
            sprintMode = false;
            moveLeft.scrollSpeed = 20.0f;
            playerAnimator.SetFloat("Sprint_f", 1.0f);            
        }
    }

    private void Jump()
    {
        // Make Player Jump
        playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Animate Jump Motion
        dirt.Stop();
        playerAnimator.SetTrigger("Jump_trig");

        // Play Jump Sound
        soundEffects.PlayOneShot(jump, 1.0f);

        // Indicate Player off the Ground
        isOnGround = false;
    }

    // Collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Start"))
        {
            playerAnimator.SetTrigger("Run_trig");
            dirt.Play();
            gameOver = false;
        }

        // If player object collides with ground
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // Indicate Player on Ground
            isOnGround = true;

            // Animate running particles
            dirt.Play();
        }
        // If player object collides with obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Indicate game over condition
            gameOver = true;
            Debug.Log("Game Over!     Final Score: " + GameManager.score);

            // Play crash sound
            music.Stop();
            soundEffects.PlayOneShot(crash, 1.0f);

            // Animate Player Death
            explosion.Play();
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            dirt.Stop();
        }
    }
}
