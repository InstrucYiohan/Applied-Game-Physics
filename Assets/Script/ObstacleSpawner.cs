using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] float spacing;
    [SerializeField] GameObject[] obstalceArray;
    [SerializeField] bool isGrounded = true;
    [SerializeField] PathCreator  pathCreator;
    [SerializeField] GameObject holder;
    [SerializeField] bool rotationIgnoreX = true;

    const float minSpacing = .1f;

    // Start is called before the first frame update

    void Start()
    {
        if(isGrounded && pathCreator != null)
        {
            DestroyObjects ();

            VertexPath path = pathCreator.path;

            spacing = Mathf.Max(minSpacing, spacing);
            float dst = 0;

            while (dst < path.length) 
            {
                if(rotationIgnoreX)
                {
                        Vector3 point = path.GetPointAtDistance (dst);
                        point.x += Random.Range(-0.7f,0.7f);
                        Instantiate(obstalceArray[Random.Range(0,3)], point, Quaternion.identity);
                        dst += spacing;
                }
                else
                {
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);
                    Instantiate(obstalceArray[Random.Range(0,2)], point, Quaternion.identity, holder.transform);
                    dst += spacing;
                }
            }
        }
        
    }
    
    void DestroyObjects () 
    {
        int numChildren = holder.transform.childCount;
        for (int i = numChildren - 1; i >= 0; i--) 
        {
            DestroyImmediate (holder.transform.GetChild (i).gameObject, false);
        }
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
