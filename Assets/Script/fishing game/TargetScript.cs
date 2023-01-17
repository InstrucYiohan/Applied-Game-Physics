using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    [SerializeField] float upperBounds;
    [SerializeField] float lowerBounds;
    Vector3 moveTargetVector; 
    // Start is called before the first frame update
    void Start()
    {
        targetPos = GetComponent<Transform>();
        randomPos();
    }

    public void randomPos()
    {
        //Get Random Number 
        float randomPos = Random.Range(lowerBounds,upperBounds);
        //Input Random Number in Local Position Y
        targetPos.localPosition = new Vector3(targetPos.localPosition.x, randomPos, targetPos.localPosition.z);
        Debug.Log(targetPos.localPosition);
    }

}
