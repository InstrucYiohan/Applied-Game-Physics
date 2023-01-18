using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
  
    private Rigidbody rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(MenuManager.MenuManagerInstance.GameState)
        {
            //desMovement();
        }
    }
    void desMovement()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        Destroy(other.gameObject);
    }

}
