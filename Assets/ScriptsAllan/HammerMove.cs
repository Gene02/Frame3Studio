using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMove : MonoBehaviour
{

    public Transform martillo;
    public float rotationSpeeed = 180f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        martillo.Rotate(Vector3.up * rotationSpeeed * Time.deltaTime);
    }
   
}

