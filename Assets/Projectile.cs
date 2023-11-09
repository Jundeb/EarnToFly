using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{    
    public float projectile_death_time = 2;
 
    void Awake()
    {
        Destroy(gameObject, projectile_death_time);
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("biplane_tag"))
        {
            Debug.Log("Virhe: ammus osui lentokoneeseen");
        }
        else {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
