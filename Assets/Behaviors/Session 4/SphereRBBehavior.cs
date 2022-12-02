using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRBBehavior : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    public float m_Thrust = 20f;

    public bool m_Force;
    public bool m_Acceleration;
    public bool m_Impulse;
    public bool m_VelocityChange;

    private ForceMode m_FMode;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update() {
        if(m_Force)
        {
            m_FMode = ForceMode.Force;

            m_Acceleration = false;
            m_Impulse = false;
            m_VelocityChange = false;

        }
        else if(m_Acceleration)
        {
            m_FMode = ForceMode.Acceleration;

            m_Force = false;
            m_Impulse = false;
            m_VelocityChange = false;

        }
        else if(m_Impulse)
        {
            m_FMode = ForceMode.Impulse;

            m_Force = false;
            m_Acceleration = false;
            m_VelocityChange = false;

        }
        else if(m_VelocityChange)
        {
            m_FMode = ForceMode.VelocityChange;

            m_Force = false;
            m_Acceleration = false;
            m_Impulse = false;

        }
    }

    private void FixedUpdate() {
        if(Input.GetButton("Jump"))
        {
            m_Rigidbody.AddForce(transform.right * m_Thrust, m_FMode);
        }
    }
}
