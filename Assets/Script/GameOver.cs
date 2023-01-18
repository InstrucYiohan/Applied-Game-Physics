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

        private void Update() 
        {
            if(playerManager.currHunger == 0)
            {
                playerManager.gameOver();
                endingText.SetText("Game Over!");
                Invoke("gameOver", 5.0f);
            }
        }

        private void OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.tag.Equals("Obstacle"))
            {
                playerManager.gameOver();
                endingText.SetText("Game Over!");
                Invoke("gameOver", 1.0f);
            }
            if(other.gameObject.tag.Equals("DeathCollider"))
            {
                playerManager.gameOver();
                endingText.SetText("Game Over!");
                Invoke("gameOver", 1.0f);
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "FinishLine")
            {
                playerManager.gameOver();
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
