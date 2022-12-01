using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private float detectorOffset;
    [SerializeField] private float speed;
    [SerializeField] private float gravitySpeed;
    private float upperBounds;
    private float lowerBounds;

    private Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementVector = transform.localPosition;

        if (Input.GetMouseButton(0))
        {

            if (transform.localPosition.y > lowerBounds - 5 && transform.localPosition.y < upperBounds)
            {
                movementVector.y += 1 * Time.deltaTime * speed;
            }
        }
        else
        {

            if (transform.localPosition.y > lowerBounds && transform.localPosition.y < upperBounds + 5)
            {
                movementVector.y += -1 * Time.deltaTime * gravitySpeed;
            }
        }

        transform.localPosition = movementVector;

    }

    public void SetBounds(float p_upperBound, float p_lowerBound)
    {
        upperBounds = p_upperBound;
        lowerBounds = p_lowerBound;
    }


    public bool IsTargetInPosition(Transform p_target)
    {
        float upperPosRange = transform.localPosition.y + detectorOffset;
        float lowerPosRange = transform.localPosition.y - detectorOffset;

        return ((p_target.localPosition.y >= lowerPosRange && p_target.localPosition.y <= upperPosRange));
    }

}
