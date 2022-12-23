using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 rotateDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
    }
}
