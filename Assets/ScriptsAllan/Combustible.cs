using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combustible : MonoBehaviour
{
    public Transform combustibleContainer;
    public float rotationSpeed = 180f;

    AudioSource audioSource;
    public AudioClip combustibleSound;

    public GameObject combustible;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.clip = combustibleSound;
            audioSource.Play();
            Destroy(gameObject, 1);
        }
    }
}
