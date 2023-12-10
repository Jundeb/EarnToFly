using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    private Button buyHealthButton, buyMoneyButton, buyAccelerationButton, buyMaxAmmoButton, buyFireRateButton;
    private StatManager statManager;
    private Upgrade healthUpgrade;
    private Upgrade moneyUpgrade;
    private Upgrade accelerationUpgrade;
    private Upgrade maxAmmoUpgrade;
    private Upgrade fireRateUpgrade;

    private void Awake()
    {
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        buyHealthButton = GameObject.FindWithTag("BuyHealthButton").GetComponent<Button>();
        buyMoneyButton = GameObject.FindWithTag("BuyMoneyButton").GetComponent<Button>();
        buyAccelerationButton = GameObject.FindWithTag("BuyAccelerationButton").GetComponent<Button>();
        buyMaxAmmoButton = GameObject.FindWithTag("BuyMaxAmmoButton").GetComponent<Button>();
        buyFireRateButton = GameObject.FindWithTag("BuyFireRateButton").GetComponent<Button>();

        healthUpgrade = new Upgrade("Health", 1.0f, statManager.healthUpgradeCost, 10);
        moneyUpgrade = new Upgrade("Money", 1.0f, statManager.moneyUpgradeCost, 10);
        accelerationUpgrade = new Upgrade("Acceleration", 1.0f, statManager.accelerationUpgradeCost, 10);
        maxAmmoUpgrade = new Upgrade("MaxAmmo", 1.0f, statManager.maxAmmoUpgradeCost, 10);
        fireRateUpgrade = new Upgrade("FireRate", 0f, statManager.fireRateUpgradeCost, 10);

    }

    void Start()
    {
        buyHealthButton.onClick.AddListener(() => PurchaseUpgrade(healthUpgrade));
        buyMoneyButton.onClick.AddListener(() => PurchaseUpgrade(moneyUpgrade));
        buyAccelerationButton.onClick.AddListener(() => PurchaseUpgrade(accelerationUpgrade));
        buyMaxAmmoButton.onClick.AddListener(() => PurchaseUpgrade(maxAmmoUpgrade));
        buyFireRateButton.onClick.AddListener(() => PurchaseUpgrade(fireRateUpgrade));
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
            else if (upgrade == moneyUpgrade)
            {
                statManager.moneyMultiplier = moneyUpgrade.Multiplier;
                statManager.moneyUpgradeCost = moneyUpgrade.Cost;
            }
            else if (upgrade == accelerationUpgrade)
            {
                statManager.accelerationMultiplier = accelerationUpgrade.Multiplier;
                statManager.accelerationUpgradeCost = accelerationUpgrade.Cost;
            }
            else if (upgrade == maxAmmoUpgrade)
            {
                statManager.maxAmmoMultiplier = (int)maxAmmoUpgrade.Multiplier;
                statManager.maxAmmoUpgradeCost = maxAmmoUpgrade.Cost;
            }
            else if (upgrade == fireRateUpgrade)
            {
                statManager.fireRateMultiplier = fireRateUpgrade.Multiplier;
                statManager.fireRateUpgradeCost = fireRateUpgrade.Cost;
            }
            Debug.Log(statManager.CurrentUpgrades[upgrade.upgradeName] + " " + upgrade.upgradeName + " upgrades purchased.");
            statManager.SaveStats();
        }
    }
}