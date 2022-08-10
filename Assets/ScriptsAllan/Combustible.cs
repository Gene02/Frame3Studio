using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combustible : MonoBehaviour
{
    public Transform combustibleContainer;
    public float rotationSpeed = 180f;

    public GameObject combustible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        combustibleContainer.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Score.scoreScript.ScoreUpdate();

            combustible.SetActive(false);

            Destroy(gameObject, 1);
        }
    }
}
