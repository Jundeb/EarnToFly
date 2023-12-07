using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;
    public float healthMultiplier;
    public int healthUpgradeCost;
    public float accelerationMultiplier;
    public int accelerationUpgradeCost;
    public float moneyMultiplier;
    public int moneyUpgradeCost;
    public int maxAmmoMultiplier;
    public int maxAmmoUpgradeCost;
    public float fireRateMultiplier;
    public int fireRateUpgradeCost;
    public Dictionary<string, int> CurrentUpgrades { get; private set; }
    public int moneyCollected;

    private void Awake()
    {
        CurrentUpgrades = new Dictionary<string, int>
        {
            { "Health", 0 },
            { "Money", 0 },
            { "Acceleration", 0 },
            { "MaxAmmo", 0 },
            { "FireRate", 0 }
        };

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadStats();
        Debug.Log("Money collected: " + moneyCollected);

    }

    public void SaveStats()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadStats()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            healthMultiplier = 1.0f;
            healthUpgradeCost = 100;
            accelerationMultiplier = 0.1f;
            accelerationUpgradeCost = 100;
            moneyMultiplier = 1.0f;
            moneyUpgradeCost = 100;
            maxAmmoMultiplier = 1;
            maxAmmoUpgradeCost = 100;
            fireRateMultiplier = 0f;
            fireRateUpgradeCost = 100;
            CurrentUpgrades["Health"] = 0;
            CurrentUpgrades["Money"] = 0;
            CurrentUpgrades["Acceleration"] = 0;
            CurrentUpgrades["MaxAmmo"] = 0;
            CurrentUpgrades["FireRate"] = 0;

            moneyCollected = 0;
            return;
        }
        healthMultiplier = data.healthMultiplier;
        healthUpgradeCost = data.healthUpgradeCost;
        accelerationMultiplier = data.accelerationMultiplier;
        accelerationUpgradeCost = data.accelerationUpgradeCost;
        moneyMultiplier = data.moneyMultiplier;
        moneyUpgradeCost = data.moneyUpgradeCost;
        maxAmmoMultiplier = data.maxAmmoMultiplier;
        maxAmmoUpgradeCost = data.maxAmmoUpgradeCost;
        fireRateMultiplier = data.fireRateMultiplier;
        fireRateUpgradeCost = data.fireRateUpgradeCost;
        CurrentUpgrades = new Dictionary<string, int>(data.currentUpgrades);
        moneyCollected = data.moneyCollected;
    }
}