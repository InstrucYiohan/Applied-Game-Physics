using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalManager : MonoBehaviour
{
    [SerializeField] private CursorBehavior cursor;
    [SerializeField] private Transform target;
    [SerializeField] private float cursorHoldPositionDuration;

    private float timer = 0;

    [Header("Bounds")]
    [SerializeField] private float UpperBounds;
    [SerializeField] private float LowerBounds;
    [Tooltip("Gives the bounds an offset for the Target position randomizer")]
    [SerializeField] private float boundsOffset;
    // Start is called before the first frame update
    void Start()
    {
        cursor.SetBounds(UpperBounds, LowerBounds);
        ResetManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (cursor.IsTargetInPosition(target))
        {
            timer += Time.deltaTime;
            if(timer >= cursorHoldPositionDuration)
            {
                ResetManager();
            }
        }
        else
        {
            timer = 0;
        }
    }

    private void ResetManager()
    {
        float ranPos = Random.Range((UpperBounds - boundsOffset), (LowerBounds + boundsOffset));

        target.localPosition = new Vector3(0, ranPos, 0);
    }



}
