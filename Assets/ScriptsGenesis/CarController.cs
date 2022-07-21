using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;

    public float turnSpeed = 0.0f;

    public float horizontalInput;

    public float forwardInput;

    public int contador;

    public Rigidbody rb;


    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        contador = contador + 1;
    }


    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Mover el vehiculo hacia adelante
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput );

        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        

       
    }
    
}
