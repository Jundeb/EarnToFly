using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform ProjectilesSpawn;
    public GameObject projectilePrefab;
    public PlayerInputButton ShootButton;

    public Vector3 projectileScale = new Vector3(0.5f,0.5f,0.5f);
    //Projectile scale

    public int ammo_max = 10;
    public int ammo_amount = 10;
    //Ammo count of the weapon
    public float reload_speed = 2.0f;
    //Reload speed at which ammo come back after shooting
    public float projectile_speed = 18.0f;
    //Projectile speed aka bullet speed
    public float fire_rate = 2.0f;
    //Projectile fire rate after which you can shoot again, the lower it is the faster you can shoot
    public const float projectile_Damage = 0.0f;
    // damage of the weapons projectiles

    private float lastShotTime = -100.0f;
    // time of the last shot
    private float lastReloadTime = 0.0f;
    // time of the last reload

    void FixedUpdate()
    {
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
    void ShootProjectile()
    {
        ammo_amount = ammo_amount - 1;
        //creates the projectile and sets its direction
        var projectile = Instantiate(projectilePrefab, ProjectilesSpawn.position, ProjectilesSpawn.rotation);
        //changes projectile scale
        projectile.gameObject.transform.localScale = projectileScale;
        //sets the speed of the projectile
        projectile.GetComponent<Rigidbody>().velocity = ProjectilesSpawn.forward * projectile_speed;
    }
}
