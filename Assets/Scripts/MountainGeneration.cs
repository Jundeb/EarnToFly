using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainGeneration : MonoBehaviour
{
    public Terrain terrain; // Assign your Terrain in the inspector
    public float scale = 0.1f; // The scale of the noise

    void Start()
    {
        TerrainData terrainData = terrain.terrainData;
        float[,] heights = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        for (int i = 0; i < terrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < terrainData.heightmapResolution; j++)
            {
                float xCoord = (float)i / terrainData.heightmapResolution * scale;
                float yCoord = (float)j / terrainData.heightmapResolution * scale;
                heights[i, j] = Mathf.PerlinNoise(xCoord, yCoord);
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }
}