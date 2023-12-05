using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance;
    public float healthMultiplier;
    public int healthUpgradeCost;
    public int maxAmmoMultiplier;
    public int maxAmmoUpgradeCost;
    public float accelerationMultiplier;
    public int accelerationUpgradeCost;
    public int moneyCollected;

    private void Awake()
    {
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
            maxAmmoMultiplier = 1;
            maxAmmoUpgradeCost = 100;
            accelerationMultiplier = 1.0f;
            accelerationUpgradeCost = 100;
            moneyCollected = 0;
            return;
        }
        healthMultiplier = data.healthMultiplier;
        healthUpgradeCost = data.healthUpgradeCost;
        maxAmmoMultiplier = data.maxAmmoMultiplier;
        maxAmmoUpgradeCost = data.maxAmmoUpgradeCost;
        accelerationMultiplier = data.accelerationMultiplier;
        accelerationUpgradeCost = data.accelerationUpgradeCost;
        moneyCollected = data.moneyCollected;
    }
}