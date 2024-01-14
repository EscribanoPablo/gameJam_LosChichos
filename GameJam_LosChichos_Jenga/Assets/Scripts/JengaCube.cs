using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaCube : MonoBehaviour
{
    Vector3 m_StartPosition;
    Quaternion m_StartRotation;
    Rigidbody m_RigidBody;

    private void Awake()
    {
       m_RigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        m_StartPosition = transform.position;
        m_StartRotation = transform.rotation;
    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        transform.position = m_StartPosition;
        transform.rotation = m_StartRotation;
        m_RigidBody.velocity = Vector3.zero;
    }
}
