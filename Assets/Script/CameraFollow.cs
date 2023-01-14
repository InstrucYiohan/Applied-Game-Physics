using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //This script keeps the camera the same distance away from the player while following the player

    [SerializeField] private Transform playerPos;
    private Vector3 offset;

    void Start()
    {
        //Automatically references the transform of "Kahel" when starting the game
        playerPos = GameObject.Find("Kahel").GetComponent<Transform>();

        //calculates the distance of the camera away from the player
        offset = transform.position - playerPos.position;
    }


    void Update()
    {
        //Makes the camera stays in the middle when moving horizontally
        Vector3 targetPos = playerPos.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
