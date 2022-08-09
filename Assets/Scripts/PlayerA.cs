using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : MonoBehaviour
{


    public Vector3 gravity;
    public Vector3 jumpSpeed;

    bool isGrounded = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
       Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = jumpSpeed;
            isGrounded = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

}
