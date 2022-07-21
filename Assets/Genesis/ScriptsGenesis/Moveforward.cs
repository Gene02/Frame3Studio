using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveforward : MonoBehaviour
{
    public int speed;

   
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
