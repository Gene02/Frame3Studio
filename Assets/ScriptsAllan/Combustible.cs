using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combustible : MonoBehaviour
{

    public GameObject combustible;
    public Transform fuel;
    public float rotationSpeeed = 180f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fuel.Rotate(Vector3.up * rotationSpeeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Score.scoreScript.ScoreUpdate();

            combustible.SetActive(false);
        }


    }
}
