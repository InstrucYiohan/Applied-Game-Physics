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
        [SerializeField] private PlayerManagerScript playerManager;
        [SerializeField] TMP_Text endingText;
        [SerializeField] private float gameOverDelay = 2f;

        private void Update() 
        {
            if(playerManager.currHunger == 0)
            {
                playerManager.stopMoving(); 
                endingText.SetText("Game Over!");
                Invoke("reloadScene", gameOverDelay);
            }
        }

        IEnumerator OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.tag.Equals("Obstacle") || other.gameObject.tag.Equals("DeathCollider"))
            {
                playerManager.stopMoving();
                endingText.SetText("Game Over!");

                yield return new WaitForSeconds(gameOverDelay);
                reloadScene();
            }
            yield return null;
        }



        void OnTriggerEnter(Collider other) 
        {
            if(other.tag == "FinishLine")
            {
                playerManager.stopMoving();
                endingText.SetText("You Won!");
            }
        }

        void reloadScene()
        {
            SceneManager.LoadScene("prototype_finals");
        }

    
    }
}
