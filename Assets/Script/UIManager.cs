using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("HungerSystem")]
    [SerializeField] GameObject[] fullHunger;
    [SerializeField] GameObject[] halfHunger;
    [SerializeField] GameObject[] blackHunger;

    [Header("References")]
    [SerializeField] PlayerManagerScript playerHunger;
    [SerializeField] GameObject kahel;


    // Start is called before the first frame update
    void Start()
    {
        kahel = GameObject.FindWithTag("Player");
        playerHunger = kahel.GetComponent<PlayerManagerScript>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = playerHunger.playerHunger; i > 0; i --)
        {
            if(i % 2 == 0)
            {
                if(playerHunger.currHunger < i)
                {
                    fullHunger[i / 2 -1].SetActive(false);
                    blackHunger[i / 2 -1].SetActive(true);
                    halfHunger[i / 2 -1].SetActive(false);
                }
                else
                {
                    fullHunger[i / 2 -1].SetActive(true);
                    blackHunger[i / 2 -1].SetActive(false);
                    halfHunger[i / 2 -1].SetActive(false);
                }
            }
            else
            {
                if(playerHunger.currHunger == i)
                {
                    halfHunger[i/2].SetActive(true);
                }
            }
        }
    }
}
