using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{    
    //projectiles death timer to make sure the projectile dies after 3 seconds
    public float projectile_death_time = 3.0f;
    void Awake()
    {
        Destroy(gameObject, projectile_death_time);
    }
    // when the projectile collides with something this happens
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("biplane_tag"))
        {
            Debug.Log("Virhe: ammus osui lentokoneeseen");
        }
        else {
            //Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
