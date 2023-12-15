using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity;


public class WarningAltitude : MonoBehaviour
{
    private Canvas canvas;
    private Canvas mainCanvas;
    private GameObject plane;
    private PlaneControlV2 planeControlV2;

    void Awake()
    {
        // Get the canvas component with tag "WarningAltitude"
        canvas = GameObject.FindWithTag("WarningCanvas").GetComponent<Canvas>();
        // Get the canvas component with tag "MainCanvas"
        mainCanvas = GameObject.FindWithTag("MainCanvas").GetComponent<Canvas>();
        plane = GameObject.FindWithTag("Player");
        planeControlV2 = GameObject.FindWithTag("Player").GetComponent<PlaneControlV2>();

    }

    void Start()
    {
        // Ensure the canvas is initially hidden
        HideCanvas();
    }

    void Update()
    {
        //if the planes altitude is greater than maxAltitude, show the canvas
        if (plane.transform.position.y > planeControlV2.maxAltitude)
        {
            ShowCanvas();
            DisableMainCanvas();
        }
        else
        {
           HideCanvas();
           EnableMainCanvas();
        }
    }
    void ShowCanvas()
    {
        // Show the canvas
        canvas.enabled = true;
    }

    void HideCanvas()
    {
        // Hide the canvas
        canvas.enabled = false;
    }

    void DisableMainCanvas()
    {
        // Disable the main canvas
        mainCanvas.enabled = false;
    }

    void EnableMainCanvas()
    {
        // Enable the main canvas
        mainCanvas.enabled = true;
    }
}