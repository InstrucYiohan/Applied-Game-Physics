using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{

    public Vector3 currentRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentRot = GetComponent<Transform>().eulerAngles;
        if ((Input.GetAxis ("Horizontal")> .2) && (currentRot.z <=8 || currentRot.z >= 350))
        {
            transform.Rotate(0, 0, 1);
        }
        if ((Input.GetAxis("Horizontal") < -.2) && (currentRot.z >=351 || currentRot.z <= 9))
        {
            transform.Rotate(0, 0, -1);
        }
        if (Input.GetAxis("Vertical") > .2)
        {
            transform.Rotate(1, 0, 0);
        }
        if (Input.GetAxis("Vertical") < -.2)
        {
            transform.Rotate(-1, 0, 0);
        }
    }
}
