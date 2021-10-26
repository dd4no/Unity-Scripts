using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Objects
    private Rigidbody playerBody;
    private Animator playerAnimation;
    private AudioSource playerAudio;

    // Actions
    public float jumpForce = 10.0f;
    public float gravityModifier = 1.0f;

    // Particles
    public ParticleSystem explosion;    
    public ParticleSystem dirt;

    // Sounds
    public AudioClip jump;    
    public AudioClip crash;

    // Flags
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Load objects
        playerBody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Modify gravity
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
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
            playerAudio.PlayOneShot(jump, 1.0f);
            // Animate jump motion
            playerAnimation.SetTrigger("Jump_trig");
            dirt.Stop();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If player object collides with ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Player object is in ground contact
            isOnGround = true;
            // Animate running particles
            dirt.Play();
        }
        // If player object collides with obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Game over
            gameOver = true;
            // Indicate game over condition
            Debug.Log("Game Over!");
            // Player is dead
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            // Play crash sound
            playerAudio.PlayOneShot(crash, 1.0f);
            // Animate player death
            dirt.Stop();
            explosion.Play();
        }
    }
}
