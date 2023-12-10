using System;
using UnityEngine;

public class Upgrade
{
    public float Multiplier { get; private set; }
    public int Cost { get; private set; }
    public int MaxUpgrades { get; private set; }
    public int CurrentUpgrades { get; private set; }
    public string upgradeName;
    private StatManager statManager;

    public Upgrade(string upgradeName, float multiplier, int initialCost, int maxUpgrades)
    {
        this.upgradeName = upgradeName;
        this.Multiplier = multiplier;
        this.MaxUpgrades = maxUpgrades;
        this.CurrentUpgrades = 0;
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        switch (upgradeName)
        {
            case "Health":
                Multiplier = statManager.healthMultiplier;
                break;
            case "Money":
                Multiplier = statManager.moneyMultiplier;
                break;
            case "Acceleration":
                Multiplier = statManager.accelerationMultiplier;
                break;
            case "MaxAmmo":
                Multiplier = statManager.maxAmmoMultiplier;
                break;
            case "FireRate":
                Multiplier = statManager.fireRateMultiplier;
                break;
        }
        Cost = initialCost;
    }

    public bool BuyUpgrade(ref int playerMoney)
    {
        if (playerMoney >= Cost && statManager.CurrentUpgrades[upgradeName] < MaxUpgrades)
        {
            if(upgradeName == "MaxAmmo")
            {
                Multiplier += 1;
            }
            else
            {
                Multiplier += 0.1f;
            }
            playerMoney -= Cost;
            Multiplier = (float)Math.Round(Multiplier, 2);
            Cost += 50;
            statManager.CurrentUpgrades[upgradeName]++;
            switch (upgradeName)
            {
                case "Health":
                    statManager.healthMultiplier = Multiplier;
                    break;
                case "Money":
                    statManager.moneyMultiplier = Multiplier;
                    break;
                case "Acceleration":
                    statManager.accelerationMultiplier = Multiplier;
                    break;
                case "MaxAmmo":
                    statManager.maxAmmoMultiplier = (int)Multiplier;
                    break;
                case "FireRate":
                    statManager.fireRateMultiplier = Multiplier;
                    break;
            }
            return true;
        }
        else if (playerMoney < Cost)
        {
            Debug.Log("Not enough money to purchase " + upgradeName);
            return false;
        }
        else if (statManager.CurrentUpgrades[upgradeName] >= MaxUpgrades)
        {
            Debug.Log("Max upgrades reached for " + upgradeName);
            return false;
        }
        return false;
    }
}