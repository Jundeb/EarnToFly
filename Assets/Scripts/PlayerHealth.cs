using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private StatManager statManager;
    private PlaneSounds planeSounds;
    public float currentHealth;
    public float maxHealth = 100;

    public Image mask;
    void Start()
    {
        if(StatManager.Instance != null)
        {
            maxHealth = StatManager.Instance.healthMultiplier * maxHealth;
        }
        currentHealth = maxHealth;
    }

    void Awake()
    {
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        planeSounds = GameObject.FindWithTag("Player").GetComponent<PlaneSounds>();
    }

    void Update()
    {
        GetCurrentFill();
    }

    public void TakeDamage(float amount)
    {
        planeSounds.PlayHitSound();
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
