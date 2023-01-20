using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineBehaviour : MonoBehaviour
{

    [SerializeField] private float delaySeconds = 2f;

    [SerializeField] private ParticleSystem finishLineEffect;
    [SerializeField] private Animator catAnimator;
    private IEnumerator OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            finishLineEffect.Play();
            catAnimator.SetBool("AtFinishLine", true);
            yield return new WaitForSeconds(delaySeconds);
            SceneManager.LoadScene("LevelTwo");

        }

    }
}
