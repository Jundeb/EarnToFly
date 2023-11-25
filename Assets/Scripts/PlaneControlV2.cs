using System;
using UnityEngine;

public class PlaneControlV2 : MonoBehaviour
{
    public float flySpeed = 10f;
    public float minSpeed = 10f;
    public float maxSpeed = 50f;
    public float flySpeedIncrement;
    public float maxAltitude = 80f;

    public float rotationSmoothing = 1.0f;
    public float correctionSpeed = 1.0f;

    private float targetPitch;

    Rigidbody rb;
    public CameraMovement cameraMovement;
    public PlayerInputButton throttleButton;
    public PlayerInputButton pitchControlUpButton;
    public PlayerInputButton pitchControlDownButton;

    //only used for propella animation
    [SerializeField] Transform propella;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs()
    {

        // Check if the pitch button is not pressed anymore (later change to work with buttons)
        if (pitchControlUpButton.ButtonState())
        {
            targetPitch = 1.0f;
        }
        else if (pitchControlDownButton.ButtonState())
        {
            targetPitch = -1.0f;
        }
        else
        {
            targetPitch = 0f;
        }

        //handle throttle value being sure to clamp it between 0 and 100
        if (throttleButton.ButtonState() || Input.GetKey(KeyCode.Space))
        {
            flySpeed += flySpeedIncrement;
        }
        else if (!throttleButton.ButtonState())
        {
            flySpeed -= flySpeedIncrement / 2;
        }

        flySpeed = Mathf.Clamp(flySpeed, minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();

        propella.Rotate(Vector3.right * flySpeed * 5);
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.right * flySpeed);

        if(transform.position.y > maxAltitude)
        {
            targetPitch = -0.5f;
        }

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0f, 0f, targetPitch * 90);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * rotationSmoothing);

        Vector3 cameraPosition = cameraMovement.transform.position;
        cameraPosition.x = Mathf.Lerp(cameraPosition.x, transform.position.x + 5f, Time.fixedDeltaTime);
        cameraMovement.transform.position = cameraPosition;
    }
}
