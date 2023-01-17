using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Target & Cursor")]
    [SerializeField] GameObject target;
    [SerializeField] Transform cursorPos;
    public bool isCaptured = false;
    Vector3 moveCursorVector; 

    [Header("Speed")]
    [SerializeField] float cursorSpeed = 5f;
    [SerializeField] float gravitySpeed = 5f;

    [Header("Boundaries")]
    [SerializeField] float upperBounds = 400;
    [SerializeField] float lowerBounds = -400;

    [Header("Time")]
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text endingText;
    float timeRemaining = 3;
    [SerializeField] float delayScene = 2f;



    // Start is called before the first frame update
    void Start()
    {
        cursorPos = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        cursorMovement();
        detectCollision();
        captureChecker();
        // Timer Text with one decimal point
        // Will show only if timer stars
        timeText.text = timeRemaining.ToString("f1"); 
    }

    void cursorMovement()
    {
        //Movement Upward
        if(Input.GetKey(KeyCode.Space))
        {
            if (cursorPos.localPosition.y <= upperBounds && cursorPos.localPosition.y >= lowerBounds)
            {
                moveCursorVector = cursorPos.localPosition;  
                moveCursorVector.y += 1 * Time.deltaTime * cursorSpeed;   
                cursorPos.localPosition = moveCursorVector; 
                //Debug.Log("I'm going up" + cursorPos.localPosition.y);
            }   
        }
        else //Movement Downward
        {
            if (cursorPos.localPosition.y <= upperBounds + 1 && cursorPos.localPosition.y >= lowerBounds + 1)
            {
                moveCursorVector = cursorPos.localPosition;  
                moveCursorVector.y -= 1 * Time.deltaTime * gravitySpeed;   
                cursorPos.localPosition = moveCursorVector; 
                //Debug.Log("I'm going down" + cursorPos.localPosition.y);
            }
        }
    }

    void detectCollision()
    {
        //Detect if Cusor Position.Y is the same as Target Position.Y
        //Get the difference of the localPosition compare to offset
        if((cursorPos.localPosition.y - target.transform.localPosition.y) <= 25 && (cursorPos.localPosition.y - target.transform.localPosition.y) >= -30 )
        {
            isCaptured = true; //Enable the captureChecker
            Debug.Log("Capturing");
            //Debug.Log("Current Postion: " + cursorPos.localPosition.y + "Target Position: " + target.transform.localPosition.y);
        }
        else // Cursor is not within the range of the fish
        {
            Debug.Log("You Lose the Fish");
            isCaptured = false;
            timeRemaining = 3;
        }
    }

    void captureChecker()
    {
        //Will start if detectCollision is true
        if(isCaptured == true)
        {
            timeRemaining -= Time.deltaTime;

            if(timeRemaining <= 0)
            {
                //Debug.Log("Congrats, You Won!");
                endingText.SetText("Congrats, Nice Catch!"); // If time ends show text
                timeRemaining = 0; 
                Invoke("reloadScene", delayScene); // Delay reload scene for 2F
            }
        } 
    }

    void reloadScene()
    {
        //Restart everything in the scene
        SceneManager.LoadScene("fishing game");
    }


}
