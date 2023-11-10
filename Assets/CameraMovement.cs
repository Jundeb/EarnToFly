using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float scrollSpeed = 5.0f;

    internal float GetCameraViewWidth()
    {
        float height = 2f * Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        return width;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * scrollSpeed * Time.fixedDeltaTime);
    }
}
