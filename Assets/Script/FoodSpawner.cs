using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] float spacing;
    [SerializeField] GameObject[] foodArray;
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
                        point.y += Random.Range(0.1f, 1.0f);
                        point.x += Random.Range(-0.7f,0.7f);
                        Instantiate(foodArray[Random.Range(0,3)], point, Quaternion.identity);
                        dst += spacing;
                }
                else
                {
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);
                    Instantiate(foodArray[Random.Range(0,2)], point, Quaternion.identity, holder.transform);
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
