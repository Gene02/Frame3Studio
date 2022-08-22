using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNPC : MonoBehaviour
{
    public AudioSource _audio;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            _audio.Play();
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            _audio.Stop();
        }
    }
}
