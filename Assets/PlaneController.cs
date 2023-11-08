using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    [Header ("Plane stats")]
    [Tooltip("How much the throttle ramps up or down")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maxium engine thrust when at 100% throttle.")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    public float responsiveness = 10f;

    private float throttle;
    private float roll;


    private float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    Rigidbody rb;
    Transform planeTransform;
    [SerializeField] Transform propella;
    public Button upButton;
    public Button downButton;
    public float correctionSpeed = 2f;
    private float lastYposition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        planeTransform = rb.transform;
    }

    private void HandleInputs()
    {
        //set rotational values from our axis inputs
        roll = Input.GetAxis("Horizontal");

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
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right * maxThrust * throttle);
        rb.AddTorque(-transform.forward * roll * responseModifier);

        if (Mathf.Abs(planeTransform.eulerAngles.z) > 0.05f && roll == 0)
        {
            // Create the desired rotation using Quaternion.Euler.
            Quaternion targetRotation = Quaternion.Euler(planeTransform.eulerAngles.x, planeTransform.eulerAngles.y, 0f);

            // Apply the z-rotation correction with the specified speed.
            planeTransform.rotation = Quaternion.Slerp(planeTransform.rotation, targetRotation, Time.deltaTime * correctionSpeed);
        }
    }
}
