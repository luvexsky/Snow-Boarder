using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            Invoke("ReloadScene", 1f);
        }

    }

    void ReloadScene()
{

         SceneManager.LoadScene(0);
}
}