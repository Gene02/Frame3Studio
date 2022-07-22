using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float moveSpeed;

    public CharacterController characterController;

    private Vector3 moveInput;

    public Transform camTransform;

    [Header("Camera")]
    public float mouseSensitivity;
   
    
    void Start()
    {
        
    }

 
    void Update()
    {
        //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed *Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");

        moveInput = horiMove + vertMove;
        moveInput.Normalize();
        moveInput = moveInput * moveSpeed;

        characterController.Move(moveInput * Time.deltaTime);

        characterController.Move(moveInput);

        //control rotacion camara
        Vector3 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;


        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camTransform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        camTransform.rotation = Quaternion.Euler(camTransform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

    }
}
