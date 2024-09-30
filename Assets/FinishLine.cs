using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] float reloadDelay = 1f; // Can be set in the inspector for flexibility

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // More efficient tag comparison
        {
            PlayFinishEffect();
            Invoke("ReloadScene", reloadDelay); // Added variable delay for flexibility
        }
    }

    void PlayFinishEffect()
    {
        if (finishEffect != null)
        {
            finishEffect.Play();
        }
        else
        {
            Debug.LogWarning("No particle effect assigned!");
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }
}
