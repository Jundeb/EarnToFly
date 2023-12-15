using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyCollection : MonoBehaviour
{
    private DistanceMeter distanceMeter;
    private StatManager statManager;
    private float distanceTravelled;
    public int moneyCollected = 0;
    private Text moneyText;
    private bool hasIncremented = false;
    private Scene currentScene;

    private void Awake()
    {
        //get moneyCollected from statManager
        statManager = GameObject.FindWithTag("StatManager").GetComponent<StatManager>();
        moneyCollected = statManager.moneyCollected;
        moneyText = GameObject.FindWithTag("MoneyMeter").GetComponent<Text>();

        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "UpgradeScreen")
        {
            distanceMeter = GameObject.FindWithTag("Player").GetComponent<DistanceMeter>();
        }
    }
    void Start()
    {
        if (StatManager.Instance != null)
        {
            moneyCollected = StatManager.Instance.moneyCollected;
        }
        if (currentScene.name != "UpgradeScreen")
        {
            distanceTravelled = distanceMeter.totalDistance;
            StartCoroutine(SaveStatsEveryFiveSeconds());
        }
        
    }

    IEnumerator SaveStatsEveryFiveSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            statManager.SaveStats();
        }
    }

    void Update()
    {
        if (currentScene.name != "UpgradeScreen")
        {
            distanceTravelled = distanceMeter.totalDistance;
            moneyText.text = moneyCollected.ToString() + " €";

            int distanceTravelledInt = (int)distanceTravelled;

            if (distanceTravelledInt % 8 == 0 && !hasIncremented)
            {
                moneyCollected += (int)Math.Round(statManager.moneyMultiplier, MidpointRounding.AwayFromZero);
                statManager.moneyCollected = moneyCollected;
                hasIncremented = true;
            }

            else if (distanceTravelledInt % 8 != 0)
            {
                hasIncremented = false;
            }

        }
        else
        {
            moneyCollected = StatManager.Instance.moneyCollected;
            moneyText.text = "Money: " + moneyCollected.ToString() + " €";
        }

    }
}
