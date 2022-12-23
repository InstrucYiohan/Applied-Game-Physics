using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBehvaiour : MonoBehaviour
{
    [SerializeField] private float destroyTimer;

    [SerializeField] private GameObject obstacle1;
    [SerializeField] private GameObject obstacle2;

    groundSpawner gs;

    

    void Start()
    {
        gs = GameObject.FindObjectOfType<groundSpawner>();

    }

    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gs.spawnGround(true);
            Destroy(gameObject, destroyTimer);
        }

    }

    public void spawnObstacle()
    {
        int randomObstacle = Random.Range(1, 3);
        int obstacleSpawnerIndex = Random.Range(2, 5);
        Transform obstacleSpawnPoint = transform.GetChild(obstacleSpawnerIndex).transform;

        if (randomObstacle == 1)
        {
            Instantiate(obstacle1, obstacleSpawnPoint.position, Quaternion.identity, transform);
        }
        if (randomObstacle == 2)
        {
            Instantiate(obstacle2, obstacleSpawnPoint.position, Quaternion.identity, transform);
        }

    }
}
