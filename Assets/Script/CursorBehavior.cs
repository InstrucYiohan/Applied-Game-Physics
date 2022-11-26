using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    public FishBehavior fishBehavior;

    [Header("Hook Area")]
    [SerializeField] Transform topBorder;
    [SerializeField] Transform bottomBorder;

    [Header("Hook Settings")]
    [SerializeField] Transform hook;
    [SerializeField] float hookSize =.18f;
    [SerializeField] float hookSpeed = .1f;
    [SerializeField] float hookGravity = .05f;

    float hookPosition;
    float hookPullVelocity;

    [Header("Progress Bar Settings")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] float hookPower;
    [SerializeField] float progressBarDecay;
    
    float catchProgress;
    public void FixedUpdate()
    {
        MoveHook();
        CheckProgress();
    }
    public void MoveHook()
    {
        if (Input.GetMouseButton(0)) //moves the hook bar
        {
            hookPullVelocity += hookSpeed * Time.deltaTime;
        }
        hookPullVelocity -= hookGravity * Time.deltaTime;
        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 <= 0 && hookPullVelocity < 0)
        { hookPullVelocity = 0; } //makes sure hook wont get stuck on either top or bottom

        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        { hookPullVelocity = 0; } //makes sure hook wont get stuck on either top or bottom

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1- hookSize / 2); //makes sure hook doesnt go out of bounds
        hook.position = Vector3.Lerp(bottomBorder.position, topBorder.position, hookPosition);
    }

    public void CheckProgress() //for the progressbar
    {
        Vector3 progressBarScale = progressBarContainer.localScale;
        progressBarScale.y = catchProgress;
        progressBarContainer.localScale = progressBarScale; //moves the progress bar

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishBehavior.fishPosition && fishBehavior.fishPosition < max)
        {
            catchProgress += hookPower * Time.deltaTime;
            if(catchProgress >= 1)
            {
                Debug.Log("You Caught It!");
            }
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
            if(catchProgress <= 0)
            {
                Debug.Log("You Lost the Fish...");
            }
        }
        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }
}
