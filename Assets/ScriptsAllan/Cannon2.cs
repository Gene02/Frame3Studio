using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon2 : MonoBehaviour
{
    public GameObject cannonBall;
    public Transform shotSpawn;
    public float delay;
    public float fireRate;
    

    public float shotForce;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);   
    }

    // Update is called once per frame
    void Update()
    {
       
        cannonBall.GetComponent<Rigidbody>().AddForce(shotSpawn.forward * shotForce);
    }
    void Fire()
    {
        Instantiate(cannonBall, shotSpawn.position, shotSpawn.rotation);
       
    }
}
