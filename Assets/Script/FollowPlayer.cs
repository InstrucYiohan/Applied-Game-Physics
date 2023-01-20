using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //This script keeps the gameObject this script is attached to, the same distance away from the player while following

    [SerializeField] private Transform playerPos;
    private Vector3 offset;

    void Start()
    {
        //Automatically references the transform of "Kahel" when starting the game
        playerPos = GameObject.Find("Kahel").GetComponent<Transform>();

        //calculates the distance away from the player
        offset = transform.position - playerPos.position;
    }


    void Update()
    {
        //Makes the camera stays in the middle when moving horizontally
        transform.position = playerPos.position + offset;
    }
}
