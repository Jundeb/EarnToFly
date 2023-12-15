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
        wing1 = transform.Find("Wing1");
        wing2 = transform.Find("Wing2");
    }

    void Update()
    {

        if (wing1 != null)
        {
            wing1.RotateAround(wing1.position, wing1.right, Mathf.Sin(Time.time * 4) * 2);
        }

        if (wing2 != null)
        {
            wing2.RotateAround(wing2.position, wing2.right, Mathf.Sin(Time.time * 4) * -2);
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