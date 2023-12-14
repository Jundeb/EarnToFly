using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class DistanceMeter : MonoBehaviour
{
    private float lastXPosition;
    internal float totalDistance = 0.0f;
    private Text distanceText; // Reference to the Text component

    private void Awake()
    {
        distanceText = GameObject.FindWithTag("DistanceMeter").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lastXPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs(transform.position.x - lastXPosition);
        totalDistance += distance;
        lastXPosition = transform.position.x;

        // Set the text of the Text component to the total distance rounded off to two decimal places
        distanceText.text = "Distance: " + Math.Round(totalDistance, 0).ToString() + " units";
    }
}