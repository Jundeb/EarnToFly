using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Bird : Enemy

{
    private GameObject plane;
    private MoneyCollection moneyCollection;
    private PlayerHealth playerHealth;
    private PlaneControlV2 planeControlV2;
    private Weapon weapon;
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
            float amplitude = 0.15f;
            float frequency = 0.75f;
            transform.position += Vector3.up * Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        else
        {
            Vector3 targetPosition = new Vector3(transform.position.x, planeControlV2.transform.position.y, transform.position.z);
            // move towards the player along the y axis
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InflictContactDamage(contactDamage);
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(weapon.projectile_Damage);
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

    private void Awake()
    {
        plane = GameObject.FindWithTag("Player");
        moneyCollection = plane.GetComponent<MoneyCollection>();
        playerHealth = plane.GetComponent<PlayerHealth>();
        planeControlV2 = plane.GetComponent<PlaneControlV2>();

        weapon = GameObject.FindWithTag("Weapon").GetComponent<Weapon>();
    }

    public void Start()
    {
        if (IsThisABird)
        {
            health = 1;
            loot = 10;
            contactDamage = 10;
            movementSpeed = 3;
        }
        else
        {
            SetColor(color2);
            health = 1;
            loot = 20;
            contactDamage = 20;
            movementSpeed = 5;
        }
        Destroy(gameObject, 30);
    }

    public void Update()
    {
        Attack();
    }
}