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

    public float GetCameraViewHeight()
    {
            Camera mainCamera = GetComponent<Camera>();
            
            Vector3 cameraPosition = Camera.main.ScreenToViewportPoint (new Vector3 (0, Camera.main.pixelHeight, 0));
            return cameraPosition.y;
    }



    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * scrollSpeed * Time.fixedDeltaTime);
    }
}
