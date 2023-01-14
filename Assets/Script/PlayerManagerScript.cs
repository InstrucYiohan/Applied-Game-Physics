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

    [Header("Coins")]
    [SerializeField] int currCoins;
    [SerializeField] int dropCoins = 1;
    [SerializeField] TMP_Text coinText;

    [Header("Health Bar")]
    [SerializeField] public int playerHealth = 6;
    private int minusHeatlh = 1;
    [SerializeField] public int currHealth;

    [Header("Food")]
    private int cherry = 1;
    private int cheese = 1;
    private int fish = 2;

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
        currCoins = 0;
        currHealth = playerHealth;    
    }

    void Update()
    {
        jumpPlayer();
        healthBarBehaviour();
        showCoinsUI();

        if(currHealth > playerHealth)
        {
            currHealth = playerHealth;
        }
    }

    void FixedUpdate()
    {
        playerMovement();
        betterJump();
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

    void healthBarBehaviour()
    {
  
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            currHealth -= minusHeatlh;
            timeRemaining = 5;
        }
        

        Debug.Log("Time: " + timeRemaining + "Health: " + currHealth);
    }
    
    void showCoinsUI()
    {
        coinText.text = "Coins: " + currCoins.ToString();
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
        if(other.tag == "FinishLine")
        {
            //newPos = new Vector3(0,0,0);
            //catSpeed = 0.0f;
        }
        //Coins
        if(other.tag =="Coin")
        {
            Destroy(other.gameObject);
            currCoins += dropCoins;
        }
        //Food
        if(other.tag == "Cherry")
        {
            currHealth -= cherry;
        }
        else if(other.tag == "Cheese" && currHealth < playerHealth)
        {
            currHealth += cheese;
        }
        else if(other.tag == "Fish" && currHealth < playerHealth )
        {
            currHealth += fish;
        }
    }

    public void stopAnimation()
    {
        catAnim.SetBool("AtFinishLine", true);
    }
}
