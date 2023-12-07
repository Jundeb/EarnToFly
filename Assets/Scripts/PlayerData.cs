using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
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
    public Dictionary<string, int> currentUpgrades;
    public int moneyCollected;


    public PlayerData(StatManager statManager)
    {
        healthMultiplier = statManager.healthMultiplier;
        healthUpgradeCost = statManager.healthUpgradeCost;
        accelerationMultiplier = statManager.accelerationMultiplier;
        accelerationUpgradeCost = statManager.accelerationUpgradeCost;
        moneyMultiplier = statManager.moneyMultiplier;
        moneyUpgradeCost = statManager.moneyUpgradeCost;
        maxAmmoMultiplier = statManager.maxAmmoMultiplier;
        maxAmmoUpgradeCost = statManager.maxAmmoUpgradeCost;
        fireRateMultiplier = statManager.fireRateMultiplier;
        fireRateUpgradeCost = statManager.fireRateUpgradeCost;
        currentUpgrades = new Dictionary<string, int>(statManager.CurrentUpgrades);
        moneyCollected = statManager.moneyCollected;
    }
}

