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
        wing1 = GameObject.FindWithTag("EagleWing1").GetComponent<Transform>();
        wing2 = GameObject.FindWithTag("EagleWing2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //roate the eagle wing up and down to simulate flying
        wing1.Rotate(Mathf.Sin(Time.time * 4) * 5f, 0, 0);
        wing2.Rotate(Mathf.Sin(Time.time * 4) * -5f, 0, 0);
    }

    private void FixedUpdate() {
        //move the eagle forward
        eagle.Translate(Vector3.left * Time.deltaTime * 5f);
    }
}