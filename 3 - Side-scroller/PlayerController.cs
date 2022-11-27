using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Objects
    private Rigidbody playerBody;
    private Animator playerAnimator;

    // Actions
    private float jumpForce = 700.0f;
    private float gravityModifier = 1.75f;

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

    void Start()
    {
        // Load Player Objects and Audio
        playerBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        soundEffects = GetComponent<AudioSource>();
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        // Modify gravity
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        // If Spacebar is pressed with player in ground contact
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // Make player object jump
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Indicate player object is not in ground contact
            isOnGround = false;

            // Play jump sound
            soundEffects.PlayOneShot(jump, 1.0f);

            // Animate jump motion
            playerAnimator.SetTrigger("Jump_trig");
            dirt.Stop();
        }

    }

    // Collisions
    private void OnCollisionEnter(Collision collision)
    {
        // If player object collides with ground
        if (collision.gameObject.CompareTag("Ground"))
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
            Debug.Log("Game Over!");

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
