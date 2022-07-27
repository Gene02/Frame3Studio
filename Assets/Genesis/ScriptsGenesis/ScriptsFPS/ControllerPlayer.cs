using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public static ControllerPlayer instance;
    public float moveSpeed;

    public CharacterController characterController;

    private Vector3 moveInput;

    public Transform camTransform;

    public float jumpPower;

    private bool canJump;

    public float runSpeed;

    public Transform groundCheckPoint;

    public LayerMask whatIsGround;

    public GameObject bullet;

    public Transform firePoint;

    [Header("Gravity")]
    public float gravityModifier;

    [Header("Camera")]
    public float mouseSensitivity;

    public Animator anim;

    

    public Gun activeGun;

    public List<Gun> allGuns = new List<Gun>();
    public int currentGun;
   
    
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);
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

        //shooting
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(camTransform.position, camTransform.forward, out hit, 50f))
            {
                if(Vector3.Distance(camTransform.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
                else
                {
                    firePoint.LookAt(camTransform.position + (camTransform.forward * 30f));

                    FireShot();
                }

            }

            if(Input.GetButtonDown("Switch Gun"))
            {
                SwitchGun();
            }


            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }

        anim.SetFloat("moveSpeed", moveInput.magnitude);
        anim.SetBool("onGround", canJump);
    }

    public void FireShot()
    {
        Instantiate(activeGun.bullet, firePoint.position, firePoint.rotation);
    }

    public void SwitchGun()
    {
        activeGun.gameObject.SetActive(false);

        currentGun++;

        if(currentGun >= allGuns.Count)
        {
            currentGun = 0;
        }

        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);
    }
}
