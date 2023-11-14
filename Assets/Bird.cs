using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy

{
    public MoneyCollection moneyCollection;
    public PlayerHealth playerHealth;
    public Color color1 = Color.blue;
    public Color color2 = Color.red;
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
        else if (collision.gameObject.CompareTag("Projectile"))
        {
            // weapon damage
        }
    }

    public override void SetColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
        else
        {
            Debug.LogError("Renderer component not found");
        }
    }

    

    public void Start()
    {
        SetColor(color1);
    }
}