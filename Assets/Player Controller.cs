using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueamount = 10f;
    [SerializeField] float boostSpeed = 5f; // Speed boost when pressing W
    [SerializeField] float slowSpeed = 2f;  // Speed reduction when pressing S
    [SerializeField] float maxSpeed = 10f;  // Maximum speed limit for the player
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        // Move forward (boost speed) when W is pressed
        if (Input.GetKey(KeyCode.W) && rb2d.velocity.magnitude < maxSpeed)
        {
            rb2d.AddForce(transform.up * boostSpeed);
        }
        
        // Slow down when S is pressed
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(-transform.up * slowSpeed);
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueamount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueamount);
        }
    }
}
