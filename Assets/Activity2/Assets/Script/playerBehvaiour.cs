using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerBehvaiour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float XMoveSpeed;
    [SerializeField] private float bulletSpeed;

    public int bulletDamage;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    Rigidbody playerRb;
    Rigidbody bulletPrefabRb;

    private bool isAlive = true;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        firePoint = transform.GetChild(0).transform;
    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            gameOver();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fire();
        }
    }

    void FixedUpdate()
    {
        if (!isAlive) return;
        playerMovement();
    }

    void playerMovement()
    {

        float XValue = Input.GetAxis("Horizontal");
        Vector3 ZMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 XMove = transform.right * XValue * speed * Time.fixedDeltaTime * XMoveSpeed;
        playerRb.MovePosition(playerRb.position + ZMove + XMove);

    }

    public void gameOver()
    {
        isAlive = false;
        Invoke("restartDelay", 2.0f);
        Debug.Log("Game Over!");
    }

    void restartDelay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void fire()
    {
       GameObject bulletTemp = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       bulletPrefabRb = bulletTemp.GetComponent<Rigidbody>();
       bulletPrefabRb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);

    }


}
