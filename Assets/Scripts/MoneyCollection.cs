using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollection : MonoBehaviour
{
    private DistanceMeter distanceMeter;
    private float distanceTravelled;
    public int moneyCollected = 0;
    private Text moneyText;
    private bool hasIncremented = false;

    private void Awake()
    {
        distanceMeter = GameObject.FindWithTag("Player").GetComponent<DistanceMeter>();
        moneyText = GameObject.FindWithTag("MoneyMeter").GetComponent<Text>();
        moneyCollected = PlayerPrefs.GetInt("MoneyCollected", 0);
    }
    void Start()
    {
        distanceTravelled = distanceMeter.totalDistance;
    }

    void Update()
    {
        distanceTravelled = distanceMeter.totalDistance;
        moneyText.text = "Money: " + moneyCollected.ToString() + " €";

        int distanceTravelledInt = (int)distanceTravelled;

        if (distanceTravelledInt % 5 == 0 && !hasIncremented)
        {
            //increment moneyCollected by one and save it to PlayerPrefs
            moneyCollected++;
            PlayerPrefs.SetInt("MoneyCollected", moneyCollected);
            hasIncremented = true;
        }

        else if (distanceTravelledInt % 5 != 0)
        {
            hasIncremented = false;
        }
    }
}
