using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy

{
    public MoneyCollection moneyCollection;
    public PlayerHealth playerHealth;
    public override void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
            DropLoot();
            Destroy(gameObject);
        }
    }
    public override void Die()
    {
        // play death animation

    }

    public override void DropLoot()
    {
        moneyCollection.moneyCollected += loot;

    }

    public override void InflictContactDamage(float amount)
    {
        playerHealth.TakeDamage(amount);
    

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InflictContactDamage(contactDamage);
            TakeDamage(1);
        }
    }

    
}