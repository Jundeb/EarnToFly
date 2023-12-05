using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public float healthMultiplier;
    public int healthUpgradeCost;
    public int maxAmmoMultiplier;
    public int maxAmmoUpgradeCost;
    public float accelerationMultiplier;
    public int accelerationUpgradeCost;
    public int moneyCollected;

    public PlayerData(StatManager statManager)
    {
        healthMultiplier = statManager.healthMultiplier;
        healthUpgradeCost = statManager.healthUpgradeCost;
        maxAmmoMultiplier = statManager.maxAmmoMultiplier;
        maxAmmoUpgradeCost = statManager.maxAmmoUpgradeCost;
        accelerationMultiplier = statManager.accelerationMultiplier;
        accelerationUpgradeCost = statManager.accelerationUpgradeCost;
        moneyCollected = statManager.moneyCollected;
    }
}

