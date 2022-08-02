using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;
    public AudioClip sonido;
    public AudioSource reproductorSonido;

    void Star()
    {
        reproductorSonido = GetComponent<AudioSource>();
    }
   
   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth.instance.HealPlayer(healAmount);

            reproductorSonido.PlayOneShot(sonido);

            Destroy(gameObject);
        }
    }
}
