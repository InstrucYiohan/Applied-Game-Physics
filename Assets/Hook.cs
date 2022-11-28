using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    [SerializeField] Transform topP;
    [SerializeField] Transform botP;

    [SerializeField] Transform hook;
    float hookPos;
    [SerializeField] float hookSz = 0.1f;
    [SerializeField] float hookPr = 0.5f;
    float hookPrg;
    float hookPullVel;
    [SerializeField] float hookPullPwr = 0.01f;
    [SerializeField] float hookGrvPwr = 0.005f;
    [SerializeField] float hookPrgDegr = 0.1f;

    [SerializeField] Transform progressBarC;

    private void Update()
    {
        FHook();
        ProgressChecking();

    }

    private void ProgressChecking()
    {

    }

    void FHook()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            hookPullVel += hookPullPwr * Time.deltaTime;
        }

        hookPullVel -= hookGrvPwr * Time.deltaTime;

        hookPos += hookPullVel;
        hookPos = Mathf.Clamp(hookPos, hookSz / 2, 1 - hookSz / 2);
        hook.position = Vector3.Lerp(botP.position, topP.position, hookPos);
    }
}
