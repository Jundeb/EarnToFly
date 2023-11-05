using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public float moveSpeed = 0;
    private float minimumSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        minimumSpeed = cameraMovement.scrollSpeed; // Initialize minimum speed after cameraMovement has been initialized
    }

    private void Update()
    {
        // Get the current velocity of the character
        Vector2 characterVelocity = rb.velocity;

        // Check if the character's speed is below the minimum speed
        if (characterVelocity.x < minimumSpeed)
        {
            // Accelerate the character to reach the minimum speed
            rb.AddForce(Vector2.right * (minimumSpeed - characterVelocity.x), ForceMode.Impulse);
        }
        Debug.Log(characterVelocity);

    }
}