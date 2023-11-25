using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 100;
    public Text healthText;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        healthText.text = "Health: " + health.ToString() + " / " + maxHealth.ToString();
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
