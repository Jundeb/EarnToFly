using System;
using UnityEngine;

public class Upgrade
{
    public float Multiplier { get; private set; }
    public int Cost { get; private set; }
    private string upgradeName;

    public Upgrade(string upgradeName, float initialMultiplier, int initialCost)
    {
        this.upgradeName = upgradeName;
        Multiplier = PlayerPrefs.GetFloat(upgradeName + "Multiplier", initialMultiplier);
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
            PlayerPrefs.SetFloat(upgradeName + "Multiplier", Multiplier);
            return true;
        }
        return false;
    }
}