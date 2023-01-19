using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lagarde
{
    public class Gravity : MonoBehaviour
    {
        Star star;
        Rigidbody rigidBody;
        public Star[] otherStars;
        private float gravitationalConstant = 6.6743f * Mathf.Pow(10, -11);
        // Start is called before the first frame update
        void Start()
        {
            star = GetComponent<Star>();
            rigidBody = GetComponent<Rigidbody>();
            otherStars = GameObject.FindObjectsOfType<Star>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            foreach (Star str in otherStars)
            {
                if (str == this.star) continue; //don't pull yourself lmao
                Vector3 dir = Vector3.Normalize(transform.position - str.transform.position);//get the direction of the object to be pulled
                float distance = Vector3.Distance(str.transform.position, transform.position);//get the distance as it will be part of the gravitation eq
                                                                                              //gravitational equation F = G * M1M2 / r^2
                float force = gravitationalConstant * ((str.Mass * star.Mass) / Mathf.Pow(distance, 2)) * Mathf.Pow(10, 7);//1/4 of 10^24
                Debug.Log("Force: " + force);
                str.StarRigidbody.AddForce(dir * force, ForceMode.Impulse);
            }
        }

    }
}