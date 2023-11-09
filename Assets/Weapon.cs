using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform ProjectilesSpawn;
    public GameObject projectilePrefab;
    public float projectilespeed = 10;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            var projectile = Instantiate(projectilePrefab, ProjectilesSpawn.position, ProjectilesSpawn.rotation);
            projectile.GetComponent<Rigidbody>().velocity = ProjectilesSpawn.forward * projectilespeed * 3;
        }
    }
    /*
    public void OnShootButtonDown()
    {
        if(Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            var projectile = Instantiate(projectilePrefab, ProjectilesSpawn.position, ProjectilesSpawn.rotation);
            projectile.GetComponent<Rigidbody>().velocity = ProjectilesSpawn.forward * projectilespeed * 3;
        }
    }
    */
}
