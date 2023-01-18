using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeroFloorDismantle : MonoBehaviour
{
    private Rigidbody rb;
    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            rb.useGravity = true;
        }
    }
}
