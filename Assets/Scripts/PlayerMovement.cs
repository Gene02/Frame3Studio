using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5;
    Rigidbody rigidBody;
    public float rotationSpeed = 1;
    public float jumpForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   

        // saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y + jumpForce, rigidBody.velocity.z);
        }
      //   mover el personaje haciad adelante y atras
        float vertical = Input.GetAxis("Vertical");
        rigidBody.velocity = transform.forward * Speed * vertical + new Vector3(0, rigidBody.velocity.y, 0);
        

        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, rotationSpeed * horizontal * Time.deltaTime, 0));

    }
        
}
