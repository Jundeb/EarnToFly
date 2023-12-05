using System;
using UnityEngine;

public class Upgrade
{
    public float Multiplier { get; private set; }
    public int Cost { get; private set; }
    private string upgradeName;
    private StatManager statManager;

    public Upgrade(string upgradeName, float v, int initialCost)
    {
        this.upgradeName = upgradeName;
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        switch (upgradeName)
        {
            case "Health":
                Multiplier = statManager.healthMultiplier;
                break;
            case "MaxAmmo":
                Multiplier = statManager.maxAmmoMultiplier;
                break;
            case "Acceleration":
                Multiplier = statManager.accelerationMultiplier;
                break;
        }
        Cost = initialCost;
    }

    public bool BuyUpgrade(ref int playerMoney)
    {
        if (playerMoney >= Cost)
        {
            playerMoney -= Cost;
            Multiplier += 0.1f;
            Multiplier = (float)Math.Round(Multiplier, 2);
            Cost += 50;
            switch (upgradeName)
            {
                case "Health":
                    statManager.healthMultiplier = Multiplier;
                    break;
                case "MaxAmmo":
                    statManager.maxAmmoMultiplier = (int)Multiplier;
                    break;
                case "Acceleration":
                    statManager.accelerationMultiplier = Multiplier;
                    break;
            }
            return true;
        }
        return false;
    }
}