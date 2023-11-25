using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    private Transform ProjectilesSpawn;
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public GameObject projectilePrefab3;
    private PlayerInputButton ShootButton;
    public Vector3 projectileScale;
    //Projectile scale

    public int ammo_max = 10;
    public int ammo_amount = 10;
    //Ammo count of the weapon
    public float reload_speed = 2.0f;
    //Reload speed at which ammo come back after shooting
    public float fire_rate = 2.0f;
    //Projectile fire rate after which you can shoot again, the lower it is the faster you can shoot
    public float projectile_Damage = 1;
    // damage of the weapons projectiles
    public float projectile_speed = 1000f;
    //Projectile speed aka bullet speed

    private float lastShotTime = -100.0f;
    // time of the last shot
    private float lastReloadTime = 0.0f;
    // time of the last reload
    private GameObject[] ProjectilesInUse;
    //The current projectiles used by the weapon
    private Vector3 ProjectilesForce;
    private float RandomAccuracy;
    private int currentProjectileIndex = 0;
    private Vector3[] projectileScales = {
        new Vector3(0.3f, 0.3f, 0.3f),
        new Vector3(1.0f, 1.0f, 1.0f),
        new Vector3(0.2f, 0.2f, 0.4f)
    };

    private float[] projectileForces;

    private void Awake()
    {
        ProjectilesSpawn = GameObject.FindWithTag("ProjectileSpawn").GetComponent<Transform>();
        ShootButton = GameObject.FindWithTag("ShootButton").GetComponent<PlayerInputButton>();
    }

    void Start()
    {
        // this will be used in final build to ensure that the settings for the weapon are right when the game starts
        ProjectilesInUse = new GameObject[] { projectilePrefab1, projectilePrefab2, projectilePrefab3 };

        projectileForces = new float[] {
            projectile_speed * 1.25f,
            projectile_speed * 1f,
            projectile_speed * 1.5f
        };

        ChangeProjectile(currentProjectileIndex);
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeToNextProjectile();
        }
        // cooldown duration has passed since last reload
        if(ammo_amount<ammo_max && Time.time - lastReloadTime >= reload_speed)
        {
            lastReloadTime = Time.time;
            ammo_amount = ammo_amount + 1;
        }
        // button is pressed and cooldown duration has passed since last shot
        if (ShootButton.ButtonState()==true && Time.time - lastShotTime >= fire_rate && ammo_amount >= 1)
        {
            ShootProjectile();
            //sets the time for the shot
            lastShotTime = Time.time;
        }
        
        print(Time.time);
    }
    void ChangeProjectile(int newIndex)
    {
        if (newIndex >= 0 && newIndex < ProjectilesInUse.Length)
        {
            ProjectilesInUse[currentProjectileIndex].SetActive(false); // Deactivate the current projectile

            currentProjectileIndex = newIndex; // Update the current index

            ProjectilesInUse[currentProjectileIndex].SetActive(true); // Activate the new projectile
            projectileScale = projectileScales[currentProjectileIndex]; // Set the scale
            ProjectilesForce = new Vector3(0, 0, projectileForces[currentProjectileIndex]); // Set the force
            // Debug.Log("Projectile " + (currentProjectileIndex + 1) + " in use");
        }
    }
    void ChangeToNextProjectile()
    {
        int newIndex = (currentProjectileIndex + 1) % ProjectilesInUse.Length; // Move to the next index cyclically
        ChangeProjectile(newIndex);
    }
    void ShootProjectile()
    {
        ammo_amount = ammo_amount - 1;
        //creates the projectile and sets its direction
        GameObject projectile = Instantiate(ProjectilesInUse[currentProjectileIndex], ProjectilesSpawn.position, ProjectilesSpawn.rotation);
        //Sets Rigid body for projectile
        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
        //changes projectile scale
        projectile.gameObject.transform.localScale = projectileScale;
        if(currentProjectileIndex==2)
        {
            RandomAccuracy = Random.Range(-150, 150);
            ProjectilesForce = new Vector3(RandomAccuracy, 0, projectileForces[currentProjectileIndex]); // Set the force
        }
        //sets the projectile to move
        projectileRigidBody.AddRelativeForce(ProjectilesForce);
    }
}
