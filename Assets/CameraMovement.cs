using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    public Transform target;
    public float fixedZPosition = -30.0f;
    public float yCameraSmoothing = 3.0f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        // Smoothly interpolate the camera's Y position toward the target's Y position with damping
        Vector3 targetPosition = new Vector3(transform.position.x, target.position.y + 8, fixedZPosition);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, Time.fixedDeltaTime*yCameraSmoothing);
        transform.Translate(Vector3.right * scrollSpeed * Time.fixedDeltaTime);
    }
}