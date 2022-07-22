using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjets : MonoBehaviour
{
    public GameObject handPoint;
    private GameObject picketObject = null;




    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            if (Input.GetMouseButtonDown(0) && picketObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = handPoint.transform.position;

                other.gameObject.transform.SetParent(handPoint.gameObject.transform);

                picketObject = other.gameObject;
            }
        }
    }
}
