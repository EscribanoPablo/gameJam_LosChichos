using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_Speed = 5.0f;
    Vector3 m_Rotation = new Vector3();
    public float m_AngularSpeed = 0.25f;
    Rigidbody m_RigidBody;
    Vector3 m_PlayerPosition;

    private void Start()
    {
        m_PlayerPosition = transform.position;
        m_Rotation = Vector3.zero;
        m_RigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        //Vector3 l_Desiredforward = Vector3.zero;
        float l_DesiredForward = 0.0f;
        float l_DesiredRight = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            //l_Desiredforward = new Vector3(0, 0, 1);
            l_DesiredForward = +1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //l_Desiredforward = new Vector3(0, 0, -1);
            l_DesiredForward = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //l_Desiredforward = new Vector3(-1, 0, 0);
            l_DesiredRight = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //l_Desiredforward = new Vector3(1, 0, 0);
            l_DesiredRight = +1;
        }
        //l_Desiredforward.Normalize();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Rotation += new Vector3(m_AngularSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Rotation += new Vector3(-m_AngularSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Rotation += new Vector3(0, m_AngularSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Rotation += new Vector3(0, -m_AngularSpeed, 0);
        }

        //transform.rotation = Quaternion.Euler(m_Rotation.x, m_Rotation.y, 0.0f);
        //transform.position = transform.position + l_Desiredforward * m_Speed * Time.deltaTime;
        m_PlayerPosition += transform.forward * l_DesiredForward * m_Speed * Time.deltaTime;
        m_PlayerPosition += transform.right * l_DesiredRight * m_Speed * Time.deltaTime;
        m_RigidBody.Move(m_PlayerPosition, Quaternion.Euler(m_Rotation.x, m_Rotation.y, 0.0f));
    }
}
