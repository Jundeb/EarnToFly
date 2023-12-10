using System;
using UnityEngine;

public class PlaneControlV2 : MonoBehaviour
{
    public float flySpeed = 20f;
    public float minSpeed = 20f;
    public float maxSpeed = 70f;
    public float flySpeedIncrement;
    public float maxAltitude = 2500f;

    public float rotationSmoothing = 1.0f;
    public float correctionSpeed = 1.0f;

    private float targetPitch;

    Rigidbody rb;
    private StatManager statManager;
    private CameraMovement cameraMovement;
    private PlayerInputButton throttleButton;
    private PlayerInputButton pitchControlUpButton;
    private PlayerInputButton pitchControlDownButton;

    //only used for propella animation
    [SerializeField] Transform propella;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        throttleButton = GameObject.FindWithTag("ThrottleButton").GetComponent<PlayerInputButton>();
        pitchControlUpButton = GameObject.FindWithTag("UpButton").GetComponent<PlayerInputButton>();
        pitchControlDownButton = GameObject.FindWithTag("DownButton").GetComponent<PlayerInputButton>();
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
            flySpeed += statManager.accelerationMultiplier;
        }
        else if (!throttleButton.ButtonState())
        {
            flySpeed -= 1;
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
        Quaternion target = Quaternion.Euler(0f, 0f, targetPitch * 60);
        Quaternion target = Quaternion.Euler(0f, 0f, targetPitch * 60);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * rotationSmoothing);

        Vector3 cameraPosition = cameraMovement.transform.position;
        cameraPosition.x = Mathf.Lerp(cameraPosition.x, transform.position.x + 5f, Time.fixedDeltaTime);
        cameraMovement.transform.position = cameraPosition;
    }
}
