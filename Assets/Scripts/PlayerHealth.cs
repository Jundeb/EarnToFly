using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private StatManager statManager;
    public float currentHealth;
    public float maxHealth;
    public Image mask;
    void Start()
    {
        maxHealth = 100f;
        if(StatManager.Instance != null)
        {
            maxHealth = StatManager.Instance.healthMultiplier * maxHealth;
        }
        currentHealth = maxHealth;
    }

    void Awake()
    {
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
    }

    void Update()
    {
        GetCurrentFill();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            statManager.SaveStats();
            SceneManager.LoadScene("UpgradeScreen");
        }
    }

        void GetCurrentFill()
    {
        float fillAmount = (float)currentHealth / (float)maxHealth;
        mask.fillAmount = fillAmount;
    }
}
