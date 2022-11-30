using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private float Speed;
    float moveY;
    private Rigidbody2D rb;
    Vector3 moveDir;
    [SerializeField]float timeRemain;
    bool TimerIsRunning;
    FishSpawner Fish;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Fish = GetComponent<FishSpawner>();
    }

    private void Awake()
    {
        TimerIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        //moves cursor up when button is held
        if (Input.GetMouseButton(0))
        {
            moveY = 1;
        }
        //else moves cursor down
        else
        {
            moveY = -1.5f;
        }
        moveDir = new Vector3(0, moveY).normalized;
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDir * Speed;
        if (TimerIsRunning == true)
        {
            if (timeRemain > 0)
            {
                timeRemain -= Time.deltaTime;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag == "Fish")
        {
            Debug.Log(timeRemain);
            TimerIsRunning = true;
            if (timeRemain <= 0)
            {
                Destroy(col.transform.gameObject);
                Fish.FishDrops();
                Fish.SpawnAFish();
                timeRemain = 2;
            }
        }
        if (col.transform.tag == "NoFish")
        {
            TimerIsRunning = false;
        }
        if (col.transform.tag == "PowerUp")
        {
            Destroy(col.transform.gameObject);
            Speed += 2;
        }
    }
}
