using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticles;  // Assign the particle system in the Inspector
    [SerializeField] string groundTag = "Ground";   // Tag to identify ground objects
    
    bool isTouchingGround = false;

    // Called when the player collides with a surface
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))  // Check if the player touches the ground
        {
            isTouchingGround = true;
            PlayParticles();
        }
    }

    // Called when the player exits collision with a surface
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))  // Check if the player leaves the ground
        {
            isTouchingGround = false;
            StopParticles();
        }
    }

    void PlayParticles()
    {
        if (dustParticles != null && !dustParticles.isPlaying)
        {
            dustParticles.Play(); // Play particle system when touching the ground
        }
    }

    void StopParticles()
    {
        if (dustParticles != null && dustParticles.isPlaying)
        {
            dustParticles.Stop(); // Stop particle system when not touching the ground
        }
    }
}
