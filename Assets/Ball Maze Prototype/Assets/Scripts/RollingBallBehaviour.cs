using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RollingBallBehaviour : MonoBehaviour
{
	[SerializeField] private Rigidbody playerRB;
	[SerializeField] private float playerMoveSpeed = 5;
	[SerializeField] private float JumpHeight = 10;
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int numberofCollectible;
    [SerializeField] private TextMeshProUGUI anotherScoreText;
    [SerializeField] private GameObject congraluationsGroup;

    private bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        numberofCollectible = collectibles.Length;
    }

    // Update is called once per frame
    void Update()
	{
		float horizontalAxis = Input.GetAxis("Horizontal");
		Vector3 horizontalMovement = Vector3.right * horizontalAxis * playerMoveSpeed * Time.deltaTime;
		playerRB.AddForce(horizontalMovement);

		float verticalAxis = Input.GetAxis("Vertical");
		Vector3 verticalMovement = Vector3.forward * verticalAxis * playerMoveSpeed * Time.deltaTime;
		playerRB.AddForce(verticalMovement);

		bool jumpButton = Input.GetButtonDown("Jump");
		if (jumpButton && canJump)
		{
			playerRB.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
		}

        if (score == numberofCollectible)
        {
            print("Game Over!");
            congraluationsGroup.SetActive(true);
            anotherScoreText.text = "You have collected " + score + " coins!";
        }

        print("Horizontal axis value: " + Input.GetAxis("Horizontal"));
		print("Vertical axis value: " + Input.GetAxis("Vertical"));
	}
		

    private void OnCollisionEnter(Collision c)
	{
		if(c.transform.tag == "Ground")
		{
			canJump = true;
		}
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Collectible")
        {
            score++;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionExit(Collision c)
	{
		if(c.transform.tag == "Ground")
		{
			canJump = false;
		}
	}

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
