using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{

    Rigidbody bulletRb;


    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }



    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Obstacle")
        {          
            Destroy(gameObject);
        }
    }



}
