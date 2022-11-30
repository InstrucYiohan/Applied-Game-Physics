using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField]Transform pfFish;
    [SerializeField] Transform pfPowerUp;
    private Vector3 SpawnPos;
    private Vector3 SpawnPow;
    float randPosition;
    float timeRemain;

    public void Setup(float timeRemain)
    {
        this.timeRemain = timeRemain;
    }
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnAFish()
    {
        randPosition = Random.Range(-3, 2.5f);
        SpawnPos = new Vector3(-0.554f, randPosition, -1f);
        Transform FishTransform = Instantiate(pfFish, SpawnPos, Quaternion.identity);
    }

    public void FishDrops()
    {
        randPosition = Random.Range(-3, 2.5f);
        SpawnPow = new Vector3(-0.554f, randPosition, -1f);
        Transform DropTransform = Instantiate(pfPowerUp, SpawnPow, Quaternion.identity);
    }
}
