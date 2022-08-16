using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject bullet;
    public float rangeToTargetPlayer, timeBetweenShots = .5f;
    private float shotCounter;

    public Transform gun, firePoint;

    /*public float rotateSpeed = 1f;*/
    void Start()
    {
        shotCounter = timeBetweenShots;
    }


    
    void Update()
    {
        if(Vector3.Distance(transform.position, ControllerPlayer.instance.transform.position) < rangeToTargetPlayer)
        {
            gun.LookAt(ControllerPlayer.instance.transform.position + new Vector3(0f, 1.2f, 0f));

            shotCounter -= Time.deltaTime;

            if(shotCounter <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }
        else
        {
            shotCounter = timeBetweenShots;

            /*gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.Euler(0f, gun.rotation.eulerAngles.y + 10f, 0f), rotateSpeed * timeBetweenShots.deltaTime);*/
        }
    }
}
