using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    Vector3 offset;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        Vector3 targetPos = playerTransform.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
