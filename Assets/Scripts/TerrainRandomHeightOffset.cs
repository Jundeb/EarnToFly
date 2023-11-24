using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainRandomHeightOffset : MonoBehaviour
{
    public Terrain terrain; // Assign your Terrain in the inspector
    public float heightOffsetRange = 0.01f; // The range of the random height offset

    void Start()
    {
        TerrainData terrainData = terrain.terrainData;
        float[,] heights = terrainData.GetHeights(0, 0, terrainData.heightmapResolution, terrainData.heightmapResolution);

        for (int i = 0; i < terrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < terrainData.heightmapResolution; j++)
            {
                float randomOffset = Random.Range(-heightOffsetRange, heightOffsetRange);
                heights[i, j] += randomOffset;
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }
}