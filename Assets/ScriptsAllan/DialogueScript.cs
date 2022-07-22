using System.Collections;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    private bool isPlayerInRange;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Se Inicia dialogo");
        }
        
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("No se inicia dialogo");
        }
    }
}
