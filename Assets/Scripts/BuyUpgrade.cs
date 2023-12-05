using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    private Button buyHealthButton, buyMaxAmmoButton, buyAccelerationButton;
    private StatManager statManager;
    private Upgrade healthUpgrade;
    private Upgrade maxAmmoUpgrade;
    private Upgrade accelerationUpgrade;

    private void Awake()
    {
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        buyHealthButton = GameObject.FindWithTag("BuyHealthButton").GetComponent<Button>();
        buyMaxAmmoButton = GameObject.FindWithTag("BuyMaxAmmoButton").GetComponent<Button>();
        buyAccelerationButton = GameObject.FindWithTag("BuyAccelerationButton").GetComponent<Button>();

        healthUpgrade = new Upgrade("Health", 1.0f, statManager.healthUpgradeCost);

        maxAmmoUpgrade = new Upgrade("MaxAmmo", 1.0f, statManager.maxAmmoUpgradeCost);

        accelerationUpgrade = new Upgrade("Acceleration", 1.0f, statManager.accelerationUpgradeCost);
    }

    void Start()
    {
        buyHealthButton.onClick.AddListener(() => PurchaseUpgrade(healthUpgrade));
        buyMaxAmmoButton.onClick.AddListener(() => PurchaseUpgrade(maxAmmoUpgrade));
        buyAccelerationButton.onClick.AddListener(() => PurchaseUpgrade(accelerationUpgrade));
    }

    void PurchaseUpgrade(Upgrade upgrade)
    {
        if (upgrade.BuyUpgrade(ref statManager.moneyCollected))
        {
            if (upgrade == healthUpgrade)
            {
                statManager.healthMultiplier = healthUpgrade.Multiplier;
                statManager.healthUpgradeCost = healthUpgrade.Cost;
            }
            else if (upgrade == maxAmmoUpgrade)
            {
                statManager.maxAmmoMultiplier = (int)maxAmmoUpgrade.Multiplier;
                statManager.maxAmmoUpgradeCost = maxAmmoUpgrade.Cost;
            }
            else if (upgrade == accelerationUpgrade)
            {
                statManager.accelerationMultiplier = accelerationUpgrade.Multiplier;
                statManager.accelerationUpgradeCost = accelerationUpgrade.Cost;
            }

            statManager.SaveStats();
        }
    }
}