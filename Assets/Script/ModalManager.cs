using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModalManager : MonoBehaviour
{
    [SerializeField] private CursorScript cursor;
    [SerializeField] private Transform target;

    [SerializeField] private float cursorHoldPositionDuration;

    [Header("Bounds")]
    [SerializeField] private float upperBounds;
    [SerializeField] private float lowerBounds;
    [Tooltip("Gives the bounds an offset for the Target position randomizer")]
    [SerializeField] private float boundsOffset;

    private float timer = 0;

    private int score = 0;
    public TextMeshProUGUI scoreText;


    void Start()
    {
        //Initialize cursor bounds
        cursor.SetBounds(upperBounds, lowerBounds);
        ResetManager();
    }


    void Update()
    {
        //Checks if target is within the cursor's position and activates timer to check how long is the position held. 
        //Resets timer to zero if gets out of position.
        if (cursor.IsTargetInPosition(target))
        {

            timer += Time.deltaTime;

            if (timer >= cursorHoldPositionDuration)
            {
                ResetManager();
                score += 1;
                scoreText.text = score.ToString("F0") + "x";
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }


    private void ResetManager()
    {
        float ranPos = Random.Range((upperBounds - boundsOffset), (lowerBounds + boundsOffset));

        target.localPosition = new Vector3(0, ranPos, 0);
    }


}
