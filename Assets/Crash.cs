using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] ParticleSystem CrashEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            CrashEffect.Play();
            Invoke("ReloadScene", 1f);
        }

    }

    void ReloadScene()
{

         SceneManager.LoadScene(0);
}
}