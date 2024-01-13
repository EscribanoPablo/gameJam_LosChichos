using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JengaCube : MonoBehaviour
{
    Vector3 m_StartPosition;
    Quaternion m_StartRotation;


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
    }
}
