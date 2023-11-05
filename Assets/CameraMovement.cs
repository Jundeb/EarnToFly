using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float scrollSpeed = 5.0f;

    private void Update()
    {
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}
