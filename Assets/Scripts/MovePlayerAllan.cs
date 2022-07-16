using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayerAllan : MonoBehaviour
{
    //variables de movimiento
    Rigidbody rig;
    public float speed = 5;
    public float jumpForce = 5;

    //variable IsGrounded
    float distToGround;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizontal);
        rig.velocity = transform.forward * vertical * speed + new Vector3(0, rig.velocity.y, 0);


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y + jumpForce, rig.velocity.z);
            
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position + Vector3.up, Vector3.up, 1);
    }
}
