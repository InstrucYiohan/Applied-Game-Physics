using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [SerializeField] private Transform target;

    private float totalDistanceMoved;

    private Vector3 previousPosition;

    [SerializeField] private float speed;

    private Vector3 movementVector;

    private float previousVelocity;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.magnitude
        //float displacementFromPreviousPosition = Vector3.Distance(previousPosition, transform.position);

        //Debug.Log(" Cube Distance to target: " + distance);

        //simple player input movement
        movementVector = transform.localPosition;  
        movementVector.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;  
        movementVector.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;  
        //movementVector.z += Input.GetAxis("Vertical") * Time.deltaTime * speed;  
        
        transform.localPosition = movementVector; 

       //Speed
        float currentSpeed = (Vector3.Distance(previousPosition, transform.position) / Time.deltaTime);

        //Velocity
        float velocity = Input.GetAxis("Vertical") * (Vector3.Distance(previousPosition, transform.position) / Time.deltaTime);

        //Acceleration
        float acceleration = (velocity - previousVelocity) / Time.deltaTime;
        
        previousVelocity = velocity;
        previousPosition = transform.position;

        Debug.Log("Velocity " + velocity + " Speed " + currentSpeed + " Acceleration " + acceleration);

    }

    public void GetPositionButton(){

        float displacementFromPreviousPosition = Vector3.Distance(previousPosition, transform.position);
        float displacementFromOrigin = Vector3.Distance( target.position, transform.position);

        totalDistanceMoved += displacementFromPreviousPosition;
        
        previousPosition = transform.position;

        //Distance is a scalar quantity as it only depends upon the magnitude and not the direction
        Debug.Log("Total Distance Moved" + totalDistanceMoved);
        //Displacement is a vector quantity as it depends upon both magnitude and direction
        Debug.Log("Displacement From Origin" + displacementFromOrigin);

    }
}
