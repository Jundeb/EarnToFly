using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CameraMovement cameraMovement;
    private Rigidbody rb;
    private bool isAccelerating = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 velocity = rb.velocity;
        // move the character along the x axis at the same speed as the camera
        transform.Translate(Vector3.right * cameraMovement.scrollSpeed * Time.deltaTime);

        // accelerate the character
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.right * 1000 * Time.deltaTime);
            isAccelerating = true;
            // if character is about to exit the cameras view, limit the speed to match the camera and dont allow the player to accelerate
            if (transform.position.x + 5f > cameraMovement.transform.position.x + cameraMovement.GetCameraViewWidth() / 2)
            {
                velocity.x = cameraMovement.scrollSpeed;
                rb.velocity = velocity;
                isAccelerating = false;
            }
        }
        else
        {
            isAccelerating = false;
        }

        // update the position of the camera to follow the character
        if (!isAccelerating)
        {
            Vector3 cameraPosition = cameraMovement.transform.position;
            cameraPosition.x = Mathf.Lerp(cameraPosition.x, transform.position.x + 5f, Time.deltaTime * 3f); // add 5f to the x position of the character
            cameraMovement.transform.position = cameraPosition;
        }

    }
}