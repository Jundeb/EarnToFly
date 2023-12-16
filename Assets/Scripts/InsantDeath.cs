using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsantDeath : Enemy
{
    private GameObject plane;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    private void Awake()
    {
        plane = GameObject.FindWithTag("Player");
        playerHealth = plane.GetComponent<PlayerHealth>();
    }

    public override void DropLoot()
    {
        //not needed
    }

    public override void Die()
    {
        //not needed
    }

    public override void TakeDamage(float amount)

    {
        //not needed
    }

    public override void Attack()
    {
        //not needed
    }


    public override void InflictContactDamage(float amount)
    {
        playerHealth.TakeDamage(amount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Get players current health and inflict the same amount of damage to the player
        if (collision.gameObject.CompareTag("Player"))
        {
            InflictContactDamage(playerHealth.currentHealth);
        }
    }
}
