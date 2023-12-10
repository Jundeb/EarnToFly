using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public GameObject[] clouds;

    void Start()
    {
        StartCoroutine(SpawnCloud());
    }

    void Update()
    {
        float cameraViewWidth = 17.78802f;
        Vector3 cameraPosition = Camera.main.transform.position;
        
        Vector3 spawnerPosition = new Vector3(cameraPosition.x + 28 + cameraViewWidth / 2 * Time.deltaTime, cameraPosition.y, transform.position.z);
        transform.position = spawnerPosition;

    }

    IEnumerator SpawnCloud()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 20));
            int randomZ = (int)Random.Range(500, 2500);
            int randomCloud = Random.Range(0, clouds.Length);  

            Vector3 spawnLocation = new Vector3(transform.position.x + 2000, transform.position.y + Random.Range(100, 200), randomZ);
            Instantiate(clouds[randomCloud], spawnLocation, Quaternion.identity);
        }

    }


}