using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellaA : MonoBehaviour
{
    public GameObject ObjPuntos;
    public float puntosQueDa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ObjPuntos.GetComponent<PuntosA>().puntos += puntosQueDa;
            Destroy(gameObject);
        }
    }
}
