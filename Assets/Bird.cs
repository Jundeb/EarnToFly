using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Bird : Enemy

{
    public MoneyCollection moneyCollection;
    public PlayerHealth playerHealth;
    public PlaneControlV2 planeControlV2;
    public Color color1 = Color.blue;
    public Color color2 = Color.red;
    public bool IsThisABird;
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

    public override void Attack()
    {
        if(IsThisABird)
        {
            // do nothing
        }
        else
        {
            Vector3 targetPosition = new Vector3(transform.position.x, planeControlV2.transform.position.y, transform.position.z);
            // move towards the player along the y axis
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
        
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
        if (IsThisABird)
        {
            SetColor(color1);
            health = 1;
            loot = 10;
            contactDamage = 10;
        }
        else
        {
            SetColor(color2);
            health = 1;
            loot = 20;
            contactDamage = 20;
            movementSpeed = 5;
        }
    }

    public void Update()
    {
        Attack();
    }
}