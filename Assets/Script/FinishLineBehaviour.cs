using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem finishLineEffect;
    [SerializeField] Animator catAnimator;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            finishLineEffect.Play();
            catAnimator.SetBool("AtFinishLine", true);
            //GetComponent<AudioSource>().Play();
        }
    }
}
