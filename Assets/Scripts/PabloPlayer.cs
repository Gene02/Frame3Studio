using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PabloPlayer : MonoBehaviour
{
    Rigidbody rig;
    public float  speed = 5;

    public Vector2 sensibility;
    private  new Transform camera;

    

    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        camera = transform.transform.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        rig.velocity = transform.forward * vertical * speed + new Vector3(0, rig.velocity.y, 0);

        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0)
        {
            transform.Rotate(Vector3.up * hor * sensibility.x);
        }
        if(ver != 0)
        {
            camera.Rotate(Vector3.left * ver * sensibility.y);
        }
        
    }
    
}
