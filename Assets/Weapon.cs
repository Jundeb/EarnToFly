using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform ProjectilesSpawn;
    public GameObject projectilePrefab;
    public float projectilespeed = 10f;
    public PlayerInputButton ShootButton;

    private float lastShotTime;
    public float cooldownDuration = 2f;
    void Update()
    {
        if (ShootButton.ButtonState() == true && Time.time - lastShotTime >= cooldownDuration)
        {
            var projectile = Instantiate(projectilePrefab, ProjectilesSpawn.position, ProjectilesSpawn.rotation);
            projectile.GetComponent<Rigidbody>().velocity = ProjectilesSpawn.forward * projectilespeed * 3;
            lastShotTime = Time.time;
        }
    }

}