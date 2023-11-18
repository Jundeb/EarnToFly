using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public Transform ProjectilesSpawn;
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public PlayerInputButton ShootButton;
    public Vector3 projectileScale;
    //Projectile scale

    public int ammo_max = 10;
    public int ammo_amount = 10;
    //Ammo count of the weapon
    public float reload_speed = 2.0f;
    //Reload speed at which ammo come back after shooting
    public float fire_rate = 2.0f;
    //Projectile fire rate after which you can shoot again, the lower it is the faster you can shoot
    public const float projectile_Damage = 0.0f;
    // damage of the weapons projectiles
    public float projectile_speed = 700f;
    //Projectile speed aka bullet speed

    private float lastShotTime = -100.0f;
    // time of the last shot
    private float lastReloadTime = 0.0f;
    // time of the last reload
    private GameObject ProjectileInUse;
    //The current projectiles used by the weapon

    void Start()
    {
        // this will be used in final build to ensure that the settings for the weapon are right when the game starts
        ProjectileInUse = projectilePrefab1;
        projectileScale = new Vector3(0.2f,0.2f,0.2f);
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeProjectile();
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
    void ChangeProjectile()
    {
        if(ProjectileInUse == projectilePrefab1) {
            ProjectileInUse = projectilePrefab2;
            projectileScale = new Vector3(0.5f,0.5f,0.5f);
        } 
        else if(ProjectileInUse == projectilePrefab2) {
            ProjectileInUse = projectilePrefab1;
            projectileScale = new Vector3(0.2f,0.2f,0.2f);
        }
    }
    void ShootProjectile()
    {
        ammo_amount = ammo_amount - 1;
        //creates the projectile and sets its direction
        GameObject projectile = Instantiate(ProjectileInUse, ProjectilesSpawn.position, ProjectilesSpawn.rotation);
        //Sets Rigid body for projectile
        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
        //changes projectile scale
        projectile.gameObject.transform.localScale = projectileScale;
        //sets the projectile to move
        projectileRigidBody.AddRelativeForce(new Vector3(0, 0, projectile_speed));

        //Old projectile
        //sets the speed of the projectile
        //projectile.GetComponent<Rigidbody>().velocity = ProjectilesSpawn.forward * projectile_speed;
    }
}
