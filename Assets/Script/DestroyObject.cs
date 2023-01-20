using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    private string[] obstacleTags = { "StopSticks", "destroy", "SafeObstacle", "Obstacle" };
    private Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision other) 
    {
        foreach (string s in obstacleTags)
        {
            if (other.gameObject.CompareTag(s))
            {
                Destroy(other.gameObject);
            }
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            Destroy(other.gameObject);
        }
    }

}
