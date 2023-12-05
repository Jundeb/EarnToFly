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

        int healthUpgradeCost = PlayerPrefs.GetInt("HealthUpgradeCost", 100);
        healthUpgrade = new Upgrade("Health", 1.0f, healthUpgradeCost);

        int maxAmmoUpgradeCost = PlayerPrefs.GetInt("MaxAmmoUpgradeCost", 200);
        maxAmmoUpgrade = new Upgrade("MaxAmmo", 1.0f, maxAmmoUpgradeCost);

        int accelerationUpgradeCost = PlayerPrefs.GetInt("AccelerationUpgradeCost", 100);
        accelerationUpgrade = new Upgrade("Acceleration", 1.0f, accelerationUpgradeCost);
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
                PlayerPrefs.SetFloat("HealthMultiplier", healthUpgrade.Multiplier);
                
                statManager.healthUpgradeCost = healthUpgrade.Cost;
                PlayerPrefs.SetInt("HealthUpgradeCost", healthUpgrade.Cost);
            }
            else if (upgrade == maxAmmoUpgrade)
            {
                statManager.maxAmmoMultiplier = (int)maxAmmoUpgrade.Multiplier;
                PlayerPrefs.SetFloat("MaxAmmoMultiplier", maxAmmoUpgrade.Multiplier);
                
                statManager.maxAmmoUpgradeCost = maxAmmoUpgrade.Cost;
                PlayerPrefs.SetInt("MaxAmmoUpgradeCost", maxAmmoUpgrade.Cost);
            }
            else if (upgrade == accelerationUpgrade)
            {
                statManager.accelerationMultiplier = accelerationUpgrade.Multiplier;
                PlayerPrefs.SetFloat("AccelerationMultiplier", accelerationUpgrade.Multiplier);
                
                statManager.accelerationUpgradeCost = accelerationUpgrade.Cost;
                PlayerPrefs.SetInt("AccelerationUpgradeCost", accelerationUpgrade.Cost);
            }

            PlayerPrefs.SetInt("MoneyCollected", statManager.moneyCollected);

        }
    }
}