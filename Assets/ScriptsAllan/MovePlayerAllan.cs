using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayerAllan : MonoBehaviour
{
    //variables de movimiento
    Rigidbody rig;
    public float speed = 5;
    

    //variable de salto
    public float jumpForce = 5;
    bool isJump = false;
    bool floorDetected = false;

    






    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizontal);
        rig.velocity = transform.forward * vertical * speed + new Vector3(0, rig.velocity.y, 0);

        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 2.03f))
        {
            floorDetected = true;
            print("Contacto con el suelo");

        }
        else
        {
            floorDetected = false;
            print("Sin contacto con el suelo");
        }
        isJump = Input.GetButtonDown("Jump");

        if (isJump && floorDetected)
        {
            rig.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        
    }
   



    
}
