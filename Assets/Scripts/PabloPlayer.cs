using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PabloPlayer : MonoBehaviour
{
    Rigidbody rig;
    public float  speed = 5;

    public Transform camera;
    float vMouse;
    float hMouse;
    float yReal = 0.0f;

    public float horizontalSpeed;
    public float verticalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        rig.velocity = transform.forward * vertical * speed + new Vector3(0, rig.velocity.y, 0);

        VistaMouse();
    }
    void VistaMouse()
    {
        hMouse = Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;
        vMouse = Input.GetAxis("Mouse Y") * verticalSpeed * Time.deltaTime;


        yReal -= vMouse;
        transform.Rotate(0, hMouse, 0);
        camera.localRotation = Quaternion.Euler(yReal, 0, 0);
    }
}
