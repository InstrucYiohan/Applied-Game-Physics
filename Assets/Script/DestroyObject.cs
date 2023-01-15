using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
     void OnTriggerEnter(Collider other) 
     {
        if (other.gameObject.tag == "destroy")
        {
            Destroy(other.gameObject);
        }
         
     }

}
