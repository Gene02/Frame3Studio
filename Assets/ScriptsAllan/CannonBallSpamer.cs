using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSpamer : MonoBehaviour
{
    public GameObject CannonBallPrefab;
    public Transform[] spawnPoints;

    public float acceleration;
    public float initialTime;
    public float minSpeed;
    public float maxSpeed;

    public float minDelay = .1f;
    public float maxDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        initialTime = Time.time;
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(Mathf.Clamp(3f - (Time.time-initialTime) * acceleration, minSpeed, maxSpeed));

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject MonsterSlimeSpamer =Instantiate(CannonBallPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(MonsterSlimeSpamer, 5f);
            

        }
    }
    
}