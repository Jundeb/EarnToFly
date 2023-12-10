using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private StatManager statManager;
    public float health;
    public float maxHealth = 100;
    public Text healthText;
    void Start()
    {
        if(StatManager.Instance != null)
        {
            maxHealth = StatManager.Instance.healthMultiplier * maxHealth;
        }
        health = maxHealth;
    }

    void Awake()
    {
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
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
            statManager.SaveStats();
            SceneManager.LoadScene("UpgradeScreen");
        }
    }
}
