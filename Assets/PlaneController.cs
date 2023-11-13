using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    [Header("Plane stats")]
    [Tooltip("How much the throttle ramps up or down")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maxium engine thrust when at 100% throttle.")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when pitching.")]
    public float responsiveness = 10f;
    [Tooltip("How fast the plane stabilizes itself.")]
    public float correctionSpeed = 2f;
    [Tooltip("How much lift force this plane generates as it gains speed.")]
    public float lift = 275f;

    private float throttle;
    private float targetPitch;
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
    public CameraMovement cameraMovement;
    public PlayerInputButton throttleButton;
    public PlayerInputButton pitchControlUpButton;
    public PlayerInputButton pitchControlDownButton;

    //only used for propella animation
    [SerializeField] Transform propella;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        planeTransform = rb.transform;
    }

    private void HandleInputs()
    {

        // Check if the pitch button is not pressed anymore (later change to work with buttons)
        if (pitchControlUpButton.ButtonState())
        {
            targetPitch = -1.0f;
        }
        else if (pitchControlDownButton.ButtonState())
        {
            targetPitch = 1.0f;
        }
        else
        {
            targetPitch = 0f;
        }

        //handle throttle value being sure to clamp it between 0 and 100
        if (throttleButton.ButtonState() || Input.GetKey(KeyCode.Space))
        {
            throttle += throttleIncrement;
        }
        else if (!throttleButton.ButtonState())
        {
            throttle -= throttleIncrement;
        }

        throttle = Mathf.Clamp(throttle, 30f, 100f);
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();

        propella.Rotate(Vector3.right * throttle * 5);
    }

    private void FixedUpdate()
    {
        if (!(transform.position.x > cameraMovement.transform.position.x + cameraMovement.GetCameraViewWidth() / 2))
        {
            rb.AddForce(transform.right * maxThrust * throttle);
        }

        rb.AddForce(Vector3.up * 4000);

        pitch = Mathf.Lerp(pitch, targetPitch, 0.1f); // Adjust the smoothing factor
        rb.AddTorque(-transform.forward * pitch * responseModifier);
        
        //Stabilaizer
        if (!pitchControlUpButton.ButtonState() && !pitchControlDownButton.ButtonState())
        {
           rb.AddTorque(-transform.forward * transform.rotation.z * correctionSpeed);
        }

        if (!throttleButton.ButtonState())
        {
            Vector3 cameraPosition = cameraMovement.transform.position;
            cameraPosition.x = Mathf.Lerp(cameraPosition.x, transform.position.x + 5f, Time.fixedDeltaTime);
            cameraMovement.transform.position = cameraPosition;
        }

    }
}
