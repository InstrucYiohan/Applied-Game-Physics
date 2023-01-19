using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lagarde
{
    public class CameraMovement : MonoBehaviour
    {
        public float movementSpeed = 5f;
        public Vector3 initialPos;
        // Start is called before the first frame update
        void Start()
        {
            initialPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector2 dir = new Vector2(x, y);

            transform.Translate(dir * movementSpeed * Time.deltaTime);
        }

        public void Reset()
        {
            transform.position = initialPos;
        }
    }
}