using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Start Game UI")]
    public static MenuManager MenuManagerInstance;
    public bool GameState;
    public GameObject menuElement;
    public GameObject hungerUI;


    // Start is called before the first frame update
    void Start()
    {
        hungerUI.SetActive(false);
        GameState = false;
        MenuManagerInstance = this;
    }

    public void startGame()
    {
        GameState = true;
        hungerUI.SetActive(true);
        menuElement.SetActive(false);
    }
}
