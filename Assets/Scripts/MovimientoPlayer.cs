using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
   public float speed = 5f;

    public Vector3 gravity;
    public Vector3 jumpSpeed;

    bool isGrounded = false;
    Rigidbody rb;
    //public float rotationSpeed = 50f;

    //  private  Rigidbody rigidbody;

    // public float VelocidadP = 0.0f;
    // public float VelocidadR = 200.0f;

    //  private float a, b;

    // public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
      //  rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moventDirection = new Vector3(horizontalInput, 0, verticalInput);
        moventDirection.Normalize();

        transform.position = transform.position + moventDirection * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = jumpSpeed;
            isGrounded = true;
        }

        //  if(moventDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moventDirection), rotationSpeed * Time.deltaTime);

        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moventDirection), rotationSpeed * Time.deltaTime);

        //   b = Input.GetAxis("Horizontal");
        //   a = Input.GetAxis("Vertical");

        //   transform.Rotate(0, b * Time.deltaTime * VelocidadR, 0);
        //  transform.Translate(0, 0, a * Time.deltaTime * VelocidadP);

        //  float hAxis = Input.GetAxisRaw("Horizontal");
        // float vAxis = Input.GetAxisRaw("Vertical");

        // rigidbody.velocity = (transform.forward * vAxis) * speed * Time.deltaTime;
        //  transform.Rotate(transform.up * hAxis) * rotationSpeed * Time.deltaTime;

    }

    void Awake()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
