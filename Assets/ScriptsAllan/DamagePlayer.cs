using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class DamagePlayer : MonoBehaviour
{
    public float healt = 100f;
    public BarraDeVida  barraDeVida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitEnemy()
    {
        healt = healt - 5;
        barraDeVida.vidaActual = healt;
        if(healt <= 0)
        {
            SceneManager.LoadScene("MainScene");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HitEnemy();
        }
    }
}
