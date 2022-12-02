using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExplosionRBBehavior : MonoBehaviour
{

    private bool explode;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionStay(Collision other) {

        // foreach(ContactPoint contact in other.)
        // {

        // }
    }


    private void FixedUpdate() {
        if(Input.GetButton("Jump"))
        {
            explode = true;
        }
    }
}
