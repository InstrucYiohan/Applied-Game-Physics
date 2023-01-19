using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lagarde
{
    public class Star : MonoBehaviour
    {
        [SerializeField] private Rigidbody starRigidbody;
        [SerializeField] private Vector3 moveDirection;
        [SerializeField] private float moveSpeed;
        private float mass;

        Transform t;
        private Vector3 defaultPosition;
        private float defaultMoveSpeed;
        private Vector3 defaultMoveDirection;

        public Rigidbody StarRigidbody { get => starRigidbody; set => starRigidbody = value; }
        public Vector3 MoveDirection { get => moveDirection; set => moveDirection = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public float Mass { get => mass; set => mass = value; }

        // Start is called before the first frame update
        void Start()
        {
            starRigidbody = GetComponent<Rigidbody>();
            t = transform;
            mass = starRigidbody.mass;
            defaultPosition = t.position;
            defaultMoveDirection = moveDirection;
            defaultMoveSpeed = moveSpeed;
        }


        public void UpdateValues(Vector3 position, Vector3 moveDirection, float moveSpeed)
        {
            t.position = position;
            this.moveDirection = moveDirection;
            this.moveSpeed = moveSpeed;
        }

        public void Reset()
        {
            t.position = defaultPosition;
            MoveDirection = defaultMoveDirection;
            MoveSpeed = defaultMoveSpeed;
            starRigidbody.velocity = Vector3.zero;
            GetComponent<MoveBody>().InitialForce();
            GetComponent<TrailRenderer>().Clear();
        }
    }
}