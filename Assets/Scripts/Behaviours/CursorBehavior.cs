using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    [SerializeField] private float detectorOffset;
    [SerializeField] private float speed;
    [SerializeField] private float gravitySpeed;
     private float UpperBounds;
     private float LowerBounds;

    private Vector3 movementVector;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = transform.localPosition;

        if (Input.GetButton("Jump"))
        {
            Debug.Log("Raising");

            if(transform.localPosition.y > LowerBounds - 5 && transform.localPosition.y < UpperBounds)
            {
                movementVector.y += 1 * Time.deltaTime * speed;
            }
        }
        else
        {
            if(transform.localPosition.y > LowerBounds && transform.localPosition.y < UpperBounds + 5)
            {
                movementVector.y += -1 * Time.deltaTime * gravitySpeed;
            }
        }

        transform.localPosition = movementVector;

    }

    public void SetBounds(float p_UpperBounds, float p_LowerBounds)
    {
        UpperBounds = p_UpperBounds;
        LowerBounds = p_LowerBounds;
    }

    public bool IsTargetInPosition(Transform p_target)
    {
       float upperPosRange = transform.localPosition.y + detectorOffset;
       float lowerPosRange = transform.localPosition.y - detectorOffset;

        return ((p_target.localPosition.y >= lowerPosRange && p_target.localPosition.y <= upperPosRange));
    }




}
