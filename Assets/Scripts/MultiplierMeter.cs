using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierMeter : MonoBehaviour
{
    [SerializeField] public string multiplierKey;
    [SerializeField] private Text multiplierText;

    private float multiplier;

    private void Awake()
    {
        multiplier = PlayerPrefs.GetFloat(multiplierKey, 1);
        if (multiplierText == null)
        {
            Debug.LogError("Multiplier Text is not assigned!");
        }
    }

    private void Update()
    {
        multiplier = PlayerPrefs.GetFloat(multiplierKey, 1);
        multiplierText.text = multiplier.ToString() + "x";
    }
}
