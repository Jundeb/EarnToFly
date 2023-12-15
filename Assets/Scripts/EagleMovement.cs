using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    private Transform eagle;
    private Transform wing1;
    private Transform wing2;

    // Start is called before the first frame update
    void Start()
    {
        eagle = GetComponent<Transform>();
        wing1 = GameObject.FindGameObjectWithTag("EagleWing1").GetComponent<Transform>();
        wing2 = GameObject.FindGameObjectWithTag("EagleWing2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eagle != null)
        {
            if (wing1 != null)
            {
                wing1.RotateAround(wing1.position, wing1.right, Mathf.Sin(Time.time * 4) * 2f);
            }
            else
            {
                Debug.LogError("Wing1 is null");
            }

            if (wing2 != null)
            {
                wing2.RotateAround(wing2.position, wing2.right, Mathf.Sin(Time.time * 4) * -2f);
            }
            else
            {
                Debug.LogError("Wing2 is null");
            }
        }
    }

    private void FixedUpdate()
    {
        //move the eagle forward
        if (eagle != null)
        {
            eagle.Translate(Vector3.left * Time.deltaTime * 5f);
        }
    }
}
