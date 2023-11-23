using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyObjects;
    public CameraMovement cameraMovement;
    public DistanceMeter distanceMeter;
    public Camera mainCamera;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 4));

            int randomIndex = Random.Range(0, enemyObjects.Length);
            Vector3 enemySpawnLocation = new Vector3(transform.position.x + 60, transform.position.y + Random.Range(-20, 20), transform.position.z);

            if (enemyObjects[randomIndex].CompareTag("Eagle") && distanceMeter.totalDistance > 500 )
            {
                Instantiate(enemyObjects[randomIndex], enemySpawnLocation, Quaternion.identity);
            }
            else if (enemyObjects[randomIndex].CompareTag("Bird"))
            {
                Instantiate(enemyObjects[randomIndex], enemySpawnLocation, Quaternion.identity);
            }
        }
    }

    private void Update()
    {

        float cameraViewWidth = cameraMovement.GetCameraViewWidth();
        Vector3 cameraPosition = Camera.main.transform.position;
        
        Vector3 spawnerPosition = new Vector3(cameraPosition.x + 28 + cameraViewWidth / 2 * Time.deltaTime, cameraPosition.y, transform.position.z);
        transform.position = spawnerPosition;

    }
}