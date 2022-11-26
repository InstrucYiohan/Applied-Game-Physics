using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    
    [Header("Fishing Area")]
    [SerializeField] Transform topBorder;
    [SerializeField] Transform bottomBorder;

    [Header("Fish Settings")]
    [SerializeField] Transform fish;
    [SerializeField] float smoothMotions = 3f;
    [SerializeField] float fishTimeRandomizer = 3f;
    

    public float fishPosition;
    float fishSpeed;
    float fishTimer;
    float fishTargetPosition;

    private void FixedUpdate()
    {
        MoveFish();
    }

    private void MoveFish() //how the fish move randomly
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0)
        {
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPosition = Random.value;
        }
        fishPosition = Mathf.SmoothDamp(fishPosition, fishTargetPosition, ref fishSpeed, smoothMotions);
        fish.position = Vector3.Lerp(bottomBorder.position, topBorder.position, fishPosition);
    }
}
