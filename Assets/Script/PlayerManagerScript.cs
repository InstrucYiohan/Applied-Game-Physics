using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManagerScript : MonoBehaviour
{

    [Header("Jump")]
    Rigidbody catRB;
    [SerializeField] bool isGrounded = true;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float holdFallMultiplier;
    [SerializeField] private float fallMultiplier;

    [Header("Movement & Position")]
    //Set the value in the editor!!!!
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;

    [Header("Hunger Bar")]
    [SerializeField] public int playerHunger = 6;
    [SerializeField] public int currHunger;
    private int minusHunger = 1;
    private int catFood = 1;


    [Header("Time")]
    private float timeRemaining = 3.0f;

    [Header("Animation")]
    [SerializeField] Animator catAnim;

    Rigidbody rb;

    void Start() 
    {
        catRB = GetComponent<Rigidbody>();
        catAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currHunger = playerHunger;    
    }

    void Update()
    {
        if(MenuManager.MenuManagerInstance.GameState)
        {
            jumpPlayer();
            hungerBarBehaviour();

            if(currHunger > playerHunger)
            {
                currHunger = playerHunger;
            }
        }
    }

    void FixedUpdate()
    {
        if(MenuManager.MenuManagerInstance.GameState)
        {
            playerMovement();
            betterJump();
        }
    }


    //This method uses the MovePosition method from the rigidbody class for the player movement
    //It takes the calculation for the forward and horizontal movement and is stored in a variable of type vector3
    //It then takes those vector3 value as an argument for the MovePosition method
    void playerMovement()
    {
        float XValue = Input.GetAxis("Horizontal");
        Vector3 forwardMove = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * XValue * forwardSpeed * Time.fixedDeltaTime * horizontalSpeed;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void jumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isGrounded = false;
            catAnim.SetBool("IsJumping", true);
            //catRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    void betterJump()
    {
        //Slower fall when "W" is hold pressed
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (holdFallMultiplier - 1) * Time.deltaTime;
        }

        //Faster fall when not holding "W"
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void hungerBarBehaviour()
    {
  
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            currHunger -= minusHunger;
            timeRemaining = 2.0f;
        }
        

        Debug.Log("Time: " + timeRemaining + "Health: " + currHunger);
    }
    

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("Ground");
            isGrounded = true;
            catAnim.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        //Finish Line Trigger
        if(other.tag == "FinishLine")
        {
            //newPos = new Vector3(0,0,0);
            //catSpeed = 0.0f;
        }

        //Hunger Trigger
        if((other.gameObject.tag == "Food") && currHunger < playerHunger)
        {
            currHunger += catFood;
        }
        if((other.gameObject.tag == "Food"))
        {
            Destroy(other.gameObject);
        }
    }

    public void stopAnimation()
    {
        catAnim.SetBool("AtFinishLine", true);
    }
}
