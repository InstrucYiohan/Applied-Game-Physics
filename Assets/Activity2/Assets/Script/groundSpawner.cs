using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{

    [SerializeField] private GameObject groundTile;

    [SerializeField] private int tileSpawnDelay;

    Vector3 nextSpawnPoint;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            if (i < tileSpawnDelay)
            {
                spawnGround(false);
            }
            else
            {
                spawnGround(true);
            }
            
        }
    }

    public void spawnGround(bool canSpawn) 
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (canSpawn)
        {
            temp.GetComponent<spawnerBehvaiour>().spawnObstacle();
        }
    }
}
