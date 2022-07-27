using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboNegro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objeto"))
        {
            Debug.Log("Genial, Solo Te falta el Ultimo");
        }
    }
}
