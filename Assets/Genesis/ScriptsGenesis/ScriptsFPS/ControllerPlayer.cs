using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float moveSpeed;

    public CharacterController characterController;

    private Vector3 moveInput;

    public Transform camTransform;

    public float jumpPower;

    private bool canJump;

    public float runSpeed;

    public Transform groundCheckPoint;

    public LayerMask whatIsGround;

    [Header("Gravity")]
    public float gravityModifier;

    [Header("Camera")]
    public float mouseSensitivity;

    public Animator anim;
   
    
    void Start()
    {
        
    }

 
    void Update()
    {
        //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed *Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float yStore = moveInput.y;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");

        moveInput = horiMove + vertMove;
        moveInput.Normalize();

        if (Input.GetButton("Run"))
        {
            moveInput = moveInput * runSpeed;
        }
        else
        {
            moveInput = moveInput * moveSpeed;
        }



        moveInput.y = yStore;

        //Gravedad
        moveInput.y += Physics.gravity.y * gravityModifier;

        if (characterController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, whatIsGround).Length > 0;

        //Salto
        if (Input.GetButtonDown("Jump") && canJump)
        {
            moveInput.y = jumpPower;
        }

        



        characterController.Move(moveInput * Time.deltaTime);

        characterController.Move(moveInput);

        //control rotacion camara
        Vector3 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;


        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camTransform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        camTransform.rotation = Quaternion.Euler(camTransform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        anim.SetFloat("moveSpeed", moveInput.magnitude);
    }
}
