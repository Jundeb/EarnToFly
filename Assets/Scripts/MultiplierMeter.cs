using UnityEngine;
using UnityEngine.UI;

public class MultiplierMeter : MonoBehaviour
{
    [SerializeField] public string multiplierKey;
    [SerializeField] private Text multiplierText;
    private float multiplier;
    private StatManager statManager;

    private void Awake()
    {
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        if (multiplierText == null)
        {
            Debug.LogError("Multiplier Text is not assigned!");
        }
    }

    private void Update()
    {
        switch (multiplierKey)
        {
            case "Health":
                multiplier = statManager.healthMultiplier;
                break;
            case "MaxAmmo":
                multiplier = statManager.maxAmmoMultiplier;
                break;
            case "Acceleration":
                multiplier = statManager.accelerationMultiplier;
                break;
            default:
                Debug.LogError("Invalid multiplier key: " + multiplierKey);
                break;
        }
        multiplierText.text = multiplier.ToString() + "x";
    }
}