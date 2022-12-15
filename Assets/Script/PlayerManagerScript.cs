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
    [SerializeField] float jumpForce = 2.0f;
    private Vector3 jump;

    [Header("Movement & Position")]
    [SerializeField] Transform catPos;
    [SerializeField] Transform forwadPos;
    [SerializeField] float catSpeed = 5.0f;
    private Vector3 newPos ;

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

    [SerializeField] PlayerMoveForward playerMoveForward;
    Rigidbody rb;
    [SerializeField] float forwardSpeed = 3.0f;

    void Start() 
    {
        catRB = GetComponent<Rigidbody>();
        catPos = GetComponent<Transform>();
        catAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currCoins = 0;
        currHealth = playerHealth;    
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        forwardPlayer();
        movePlayer();
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
        forwardPlayer();
    }

    void forwardPlayer()
    {
        rb.MovePosition(transform.position + (transform.forward * forwardSpeed * Time.deltaTime));
    }

    void movePlayer()
    {

        float xPostion = catPos.position.x * catSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.D))
        {
            //Move Left
            newPos = catPos.localPosition;  
            newPos.x += 1f * Time.deltaTime * catSpeed;
            newPos.z = forwadPos.localPosition.z;
            catPos.localPosition = newPos; 
        }
        if(Input.GetKey(KeyCode.A))
        {
            //Move Right
            newPos = catPos.localPosition;  
            newPos.x -= 1f * Time.deltaTime * catSpeed;  
            newPos.z = forwadPos.localPosition.z; 
            catPos.localPosition = newPos; 
        }
    }

    void jumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isGrounded = false;
            catPos.rotation = Quaternion.identity;
            catRB.AddForce(jump * jumpForce, ForceMode.Impulse);
            catAnim.SetBool("IsJumping", true);
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
            forwardSpeed = 0;
            //newPos = new Vector3(0,0,0);
            //catSpeed = 0.0f;
            playerMoveForward.stopMovement();
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
