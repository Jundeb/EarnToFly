using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    [Header ("Plane stats")]
    [Tooltip("How much the throttle ramps up or down")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maxium engine thrust when at 100% throttle.")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when pitching.")]
    public float responsiveness = 10f;
    [Tooltip("How fast the plane stabilizes itself.")]
    public float correctionSpeed = 2f;

    private float throttle;
    private float pitch;


    private float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    Rigidbody rb;
    Transform planeTransform;

    //only used for propella animation
    [SerializeField] Transform propella;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        planeTransform = rb.transform;
    }

    public void OnUpButtonDown()
    {
        if (pitch >= -1.0f)
        {
            pitch -= throttleIncrement;
        }
    }

    // Add this method to handle the downButton click event.
    public void OnDownButtonDown()
    {
        if (pitch <= 1.0f)
        {
            pitch += throttleIncrement;
        }
    }
    private void HandleInputs()
    {

        //handle throttle value being sure to clamp it between 0 and 100
        if (Input.GetKey(KeyCode.Space))
        {
            throttle += throttleIncrement;
        }
        else if(throttle >= 5)
        {
            throttle -= throttleIncrement;
        }
        else
        {
            throttle = 5;
        }

        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();

        propella.Rotate(Vector3.right * throttle);

        // Check if the pitch button is not pressed anymore
        if (!EventSystem.current.IsPointerOverGameObject() && !Input.GetMouseButton(0))
        {
            pitch = 0f;
            Debug.Log("Pitch set to 0");
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right * maxThrust * throttle);
        rb.AddTorque(-transform.forward * pitch * responseModifier);

        //stabilization
        if (Mathf.Abs(planeTransform.eulerAngles.z) > 0.05f && pitch == 0)
        {
            // Create the desired rotation using Quaternion.Euler.
            Quaternion targetRotation = Quaternion.Euler(planeTransform.eulerAngles.x, planeTransform.eulerAngles.y, 0f);

            // Apply the z-rotation correction with the specified speed.
            planeTransform.rotation = Quaternion.Slerp(planeTransform.rotation, targetRotation, Time.deltaTime * correctionSpeed);
        }
    }
}
