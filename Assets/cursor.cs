using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    [SerializeField] Transform topP;
    [SerializeField] Transform botP;

    [SerializeField] Transform fish;

    float fishPos;
    float fishDes;

    float fishT;
    [SerializeField] float timerM = 3f;

    float fishS;
    [SerializeField] float smoothM = 1f;

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

    bool pause = false;

    [SerializeField] float failTime = 10f;

    private void Update()
    {


        Fish();
        FHook();
        ProgressChecking();

    }

    private void ProgressChecking()
    {
        Vector3 ls = progressBarC.localScale;
        ls.y = hookPrg;
        progressBarC.localScale = ls;

        float min = hookPos - hookSz / 2;
        float max = hookPos + hookSz / 2;

        if (min < fishPos && fishPos < max)
        {
            hookPrg += hookPr * Time.deltaTime;
        }
        else
        {
            hookPrg -= hookPrgDegr * Time.deltaTime;

            failTime -= Time.deltaTime;
            if(failTime < 0f)
            {
                Lose();
            }
        }

        if(hookPrg >= 1f)
        {
            Win();
        }

        hookPrg = Mathf.Clamp(hookPrg, 0f, 1f);
    }

    private void Win()
    {
        pause = true;
        Debug.Log("You WIN!");
    }

    private void Lose()
    {
        pause = true;
        Debug.Log("You LOSE!");
    }

    void FHook()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            hookPullVel += hookPullPwr * Time.deltaTime;
        }

        hookPullVel -= hookGrvPwr * Time.deltaTime;

        if(hookPos - hookSz / 2 <= 0f && hookPullVel < 0f)
        {
            hookPullVel = 0f;
        }
        if(hookPos + hookSz / 2 >= 1f && hookPullVel > 0f)
        {
            hookPullVel = 0f;
        }

        hookPos += hookPullVel;
        hookPos = Mathf.Clamp(hookPos, hookSz / 2, 1 - hookSz / 2);
        hook.position = Vector3.Lerp(botP.position, topP.position, hookPos);
    }

    void Fish()
    {
        fishT -= Time.deltaTime;
        if (fishT < 0f)
        {
            fishT = UnityEngine.Random.value * timerM;

            fishDes = UnityEngine.Random.value;
        }

        fishPos = Mathf.SmoothDamp(fishPos, fishDes, ref fishS, smoothM);
        fish.position = Vector3.Lerp(botP.position, topP.position, fishPos);
    }

}
