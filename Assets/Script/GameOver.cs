using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PathCreation;
using TMPro;

namespace PathCreation.Examples
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] PlayerManagerScript playerManager;
        [SerializeField] TMP_Text endingText;
        [SerializeField] GameObject toast;
        [SerializeField] GameObject toastHolder;

        private void Update() 
        {
            if(playerManager.currHunger == 0)
            {
                endingText.SetText("Game Over!");
                Invoke("gameOver", 5.0f);
            }
        }

        private void OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.tag.Equals("Obstacle"))
            {
                endingText.SetText("Game Over!");
                Invoke("gameOver", 1.0f);
            }
            if(other.gameObject.tag.Equals("DeathCollider"))
            {
                endingText.SetText("Game Over!");
                Invoke("gameOver", 1.0f);
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "FinishLine")
            {
                endingText.SetText("You Won!");
                Invoke("gameOver", 1.0f);
            }
        }

        public void gameOver()
        {
            playerManager.stopAnimation();
            SceneManager.LoadScene("prototype_finals");
        }

    }
}
