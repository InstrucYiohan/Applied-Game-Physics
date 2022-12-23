using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class obstacleBehaviour : MonoBehaviour
{
    [SerializeField] private float health;

    [SerializeField] TMP_Text healthText;

    playerBehvaiour pb;

    void Start()
    {
        pb = GameObject.FindObjectOfType<playerBehvaiour>();
    }

    void Update()
    {
        healthText.text = health.ToString();
    }

    void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pb.gameOver();
        }

        if (collision.gameObject.tag == "Bullet")
        {
            takeDamage(pb.bulletDamage);
        }
    }
}
