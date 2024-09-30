using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float reloadDelay = 1f; // Time delay before reloading the scene
    [SerializeField] AudioSource crashSound; // Optional: crash sound effect

    bool hasCrashed = false; // Prevents multiple triggers

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") && !hasCrashed) // Use CompareTag for better performance
        {
            hasCrashed = true; // Ensure the crash is only handled once
            PlayCrashEffect();
            Invoke("ReloadScene", reloadDelay); // Reload the scene after a delay
        }
    }

    void PlayCrashEffect()
    {
        if (crashEffect != null)
        {
            crashEffect.Play(); // Play crash particle effect
        }
        else
        {
            Debug.LogWarning("No crash effect assigned!");
        }

        if (crashSound != null)
        {
            crashSound.Play(); // Optional: Play a crash sound effect
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }
}
