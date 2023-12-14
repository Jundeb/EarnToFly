using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyObjects;
    public CameraMovement cameraMovement;
    private DistanceMeter distanceMeter;

    private void Awake ()
    {
        distanceMeter = GameObject.FindWithTag("Player").GetComponent<DistanceMeter>();
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            Vector3 BirdRotation = new Vector3(0, -90, 0);

            int randomIndex = Random.Range(0, enemyObjects.Length);
            Vector3 enemySpawnLocation = new Vector3(transform.position.x + 60, transform.position.y + Random.Range(-15, 5), transform.position.z);

            if (enemyObjects[randomIndex].CompareTag("HotAirBalloonV1") && distanceMeter.totalDistance > 4000 )
            {
                Instantiate(enemyObjects[randomIndex], enemySpawnLocation, Quaternion.identity);
            }
            else if (enemyObjects[randomIndex].CompareTag("HotAirBalloonV2") && distanceMeter.totalDistance > 6000 )
            {
                Instantiate(enemyObjects[randomIndex], enemySpawnLocation, Quaternion.identity);
            }
            else if (enemyObjects[randomIndex].CompareTag("HotAirBalloonV3") && distanceMeter.totalDistance > 8000 )
            {
                Instantiate(enemyObjects[randomIndex], enemySpawnLocation, Quaternion.identity);
            }
            else if (enemyObjects[randomIndex].CompareTag("Eagle") && distanceMeter.totalDistance > 2000 )
            {
                Instantiate(enemyObjects[randomIndex], enemySpawnLocation, Quaternion.identity);
            }
            else if (enemyObjects[randomIndex].CompareTag("Bird"))
            {
                Instantiate(enemyObjects[randomIndex], enemySpawnLocation, Quaternion.Euler(BirdRotation));
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