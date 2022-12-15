using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 3.0f;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveForward();
    }

    void moveForward()
    {
        rb.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
    }

    public void stopMovement()
    {
        speed = 0;
        rb.MovePosition(new Vector3(0,0,0));
    }
}
