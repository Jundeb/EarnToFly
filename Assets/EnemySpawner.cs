using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyObjects;
    public CameraMovement cameraMovement;
    public float speed = 1f; // speed of movement along y-axis
    public float top; // how high the spawner should go before going back down
    public float bottom; // how low the spawner should go before going back up
    private bool movingUp = true; // flag to indicate direction of movement

    public Camera mainCamera;

    private void Start()
    {
        // Get the camera's frustum planes
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        // Get the object's bounds
        Bounds bounds = GetComponent<Renderer>().bounds;

        // Check if the bounds are outside any of the camera's frustum planes
        if (!GeometryUtility.TestPlanesAABB(planes, bounds))
        {
            // Object is outside the camera's view
        }
    }
    private void Update()
    {

        float cameraViewWidth = cameraMovement.GetCameraViewWidth();
        Vector3 cameraPosition = Camera.main.transform.position;

        Vector3 spawnPosition = new Vector3(cameraPosition.x + 28 + cameraViewWidth / 2 * Time.deltaTime, transform.position.y, transform.position.z);

        transform.position = spawnPosition;

        // Get the camera's frustum planes
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        

        // Get the object's bounds
        Bounds bounds = GetComponent<Renderer>().bounds;



        // Check if the bounds are outside any of the camera's frustum planes
        if (GeometryUtility.TestPlanesAABB(planes, bounds))
        {
            // Object is outside the camera's view
            if (movingUp)
            {
                // move up along y-axis
                transform.Translate(Vector3.up * speed * Time.deltaTime);

                // check if object has reached top of bounds
                if (transform.position.y >= top)
                {
                    movingUp = false;
                }
            }
            else
            {
                // move down along y-axis
                transform.Translate(Vector3.down * speed * Time.deltaTime);

                // check if object has reached bottom of bounds
                if (transform.position.y <= bottom)
                {
                    movingUp = true;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            int randomIndex = Random.Range(0, enemyObjects.Length);
            Instantiate(enemyObjects[randomIndex], transform.position, Quaternion.identity);
        }
    }
}