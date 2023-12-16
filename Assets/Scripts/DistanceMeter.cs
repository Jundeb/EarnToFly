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

    }
}