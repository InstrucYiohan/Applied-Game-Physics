using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIScript : MonoBehaviour
{
    [SerializeField] GameObject[] fullHearts;
    [SerializeField] GameObject[] halfHearts;
    [SerializeField] GameObject[] blackHearts;

    [SerializeField] PlayerManagerScript playerHealthScript;
    [SerializeField] GameObject toast;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthScript = toast.GetComponent<PlayerManagerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = playerHealthScript.playerHealth; i > 0; i --)
        {
            if(i % 2 == 0)
            {
                if(playerHealthScript.currHealth < i)
                {
                    fullHearts[i / 2 -1].SetActive(false);
                    blackHearts[i / 2 -1].SetActive(true);
                    halfHearts[i / 2 -1].SetActive(false);
                }
                else
                {
                    fullHearts[i / 2 -1].SetActive(true);
                    blackHearts[i / 2 -1].SetActive(false);
                    halfHearts[i / 2 -1].SetActive(false);
                }
            }
            else
            {
                if(playerHealthScript.currHealth == i)
                {
                    halfHearts[i/2].SetActive(true);
                }
            }
        }
    }
}
