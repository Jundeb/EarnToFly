using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class DistanceMeter : MonoBehaviour
{
    private Vector3 lastPosition;
    internal float totalDistance = 0.0f;
    public Text distanceText; // Reference to the Text component

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, lastPosition);
        totalDistance += distance;
        lastPosition = transform.position;

        // Set the text of the Text component to the total distance rounded off to two decimal places
        distanceText.text = "Distance: " + Math.Round(totalDistance, 0).ToString() + " units";
    }
}