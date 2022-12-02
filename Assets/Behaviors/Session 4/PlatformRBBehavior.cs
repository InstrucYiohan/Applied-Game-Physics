using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRBBehavior : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.body != null)
        {

            Debug.Log("Object Collided");
            Rigidbody rb = (Rigidbody)other.body;

            rb.AddForce(other.gameObject.transform.up * 400, ForceMode.VelocityChange);

        }
    }
}
