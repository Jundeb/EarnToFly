using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTreeRenderDistance : MonoBehaviour
{
    public float distance;
    public Terrain terrain;
	void Start () {
        terrain.treeDistance = distance;
    }
}
