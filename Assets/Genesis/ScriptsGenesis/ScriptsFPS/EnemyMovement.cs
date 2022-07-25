using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    private bool chasing;
    public float distanceToChase = 10f, distanceToLose = 15f, distanceToStop;

    private Vector3 targetPoint, startPoint;

    public NavMeshAgent agent;

    public float keepChasingTime = 5f;
    private float chaseCounter;

    public GameObject bullet;
    public Transform firePoint;

    public float fireRate, waitBetweenShots = 2f, timeToShoot = 1f;
    private float fireCount, shotWaitCounter, shootTimeCounter;


    
    void Start()
    {
        startPoint = transform.position;

        shootTimeCounter = timeToShoot;
        shotWaitCounter = waitBetweenShots;
    }

    
    void Update()
    {
        targetPoint = ControllerPlayer.instance.transform.position;
        targetPoint.y = transform.position.y;

        if (!chasing)
        {
            if(Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                chasing = true;

                shootTimeCounter = timeToShoot;
                shotWaitCounter = waitBetweenShots;
            }

            if(chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;

                if(chaseCounter <= 0)
                {
                    agent.destination = startPoint;
                }
            }

        } else
        {
            //transform.LookAt(targetPoint);
            //rig.velocity = transform.forward * moveSpeed;

            agent.destination = targetPoint;

            if(Vector3.Distance(transform.position, targetPoint) > distanceToLose)
            {
                chasing = false;

                chaseCounter = keepChasingTime;
            }

            if (shotWaitCounter > 0)
            {
                shotWaitCounter -= Time.deltaTime;

                if (shotWaitCounter <= 0)
                {
                    shootTimeCounter = timeToShoot;
                }
            }
            else
            {
                if(ControllerPlayer.instance.gameObject.activeInHierarchy)
                {
                    shootTimeCounter -= Time.deltaTime;

                    if (shootTimeCounter > 0)
                    {
                        fireCount -= Time.deltaTime;

                        if (fireCount <= 0)
                        {
                            fireCount = fireRate;

                            firePoint.LookAt(ControllerPlayer.instance.transform.position + new Vector3(0f, 1.5f, 0f));

                            //angulo de jugador
                            Vector3 targetDir = ControllerPlayer.instance.transform.position - transform.position;
                            float angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.down);

                            if (Mathf.Abs(angle) < 30f)
                            {
                                Instantiate(bullet, firePoint.position, firePoint.rotation);
                            }
                            else
                            {
                                shotWaitCounter = waitBetweenShots;
                            }


                        }

                        agent.destination = transform.position;

                    }
                    else
                    {
                        shotWaitCounter = waitBetweenShots;
                    }
                }


            }

        }
    }
                
}
