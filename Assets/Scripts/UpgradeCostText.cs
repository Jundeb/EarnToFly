using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line

public class UpgradeCostText : MonoBehaviour
{
    [SerializeField] public string costKey;
    [SerializeField] private Text costText;
    private int cost;
    private StatManager statManager;

    private void Awake()
    {
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        if (costText == null)
        {
            Debug.LogError("MultiplierCost Text is not assigned!");
        }
    }

    private void Update()
    {
        switch (costKey)
        {
            case "Health":
                cost = statManager.healthUpgradeCost;
                break;
            case "Money":
                cost = statManager.moneyUpgradeCost;
                break;
            case "Acceleration":
                cost = statManager.accelerationUpgradeCost;
                break;
            case "MaxAmmo":
                cost = statManager.maxAmmoUpgradeCost;
                break;
            case "FireRate":
                cost = statManager.fireRateUpgradeCost;
                break;
            default:
                Debug.LogError("Invalid cost key: " + costKey);
                break;
        }
        costText.text = costKey + ": " + cost.ToString() + " €";
    }
}