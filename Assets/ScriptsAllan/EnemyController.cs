using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public float speed;
    //public AudioClip Bones;
    //AudioSource audio;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Move(Vector3 target, float speed = 0)
    {
        // If the AI controller didn't provide speed, use the default
        if (speed == 0) speed = this.speed;

        transform.LookAt(target);
        rb.velocity = transform.forward * speed + Vector3.down * rb.velocity.y;


    }
   


}
