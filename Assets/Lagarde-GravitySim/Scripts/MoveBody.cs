using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lagarde
{
    public class MoveBody : MonoBehaviour
    {
        Star star;
        // Start is called before the first frame update
        void Start()
        {
            star = GetComponent<Star>();
            InitialForce();
        }

        public void InitialForce()
        {
            star.StarRigidbody.AddForce((star.MoveSpeed / 4f) * star.MoveDirection, ForceMode.VelocityChange);
        }

    }

}