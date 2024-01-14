using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    Vector3 m_StartPosition;
    Quaternion m_StartRotation;

    public float m_BaseSpeed = 5.0f;
    float m_Speed;
    public float m_MaxSpeed = 5.0f;
    float m_Acceleration = 3.0f;
    Vector3 m_Rotation = new Vector3();
    public float m_AngularSpeed = 0.25f;
    Rigidbody m_RigidBody;
    Vector3 m_PlayerPosition;
    float m_DesiredForward;
    float m_DesiredRight;

    public GameController m_GameController;

    //[Range(0, 5.0f)]
    //public float m_MaxNoise;
    //Vector3 m_HandNoise;
    //float m_NoiseCounter = 0;
    //public float m_NoiseCounterMaxTime;

    private void Start()
    {
        m_StartPosition = transform.position;
        m_StartRotation = transform.rotation;

        m_PlayerPosition = transform.position;
        m_Rotation = Vector3.zero;
        m_RigidBody = gameObject.GetComponent<Rigidbody>();
        m_DesiredForward = 0;
        m_DesiredRight = 0;
    }

    void Update()
    {
        if (m_GameController.GetRoundActive())
        {
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        //Vector3 l_Desiredforward = Vector3.zero;

        //m_DesiredForward = 0;
        //m_DesiredRight = 0;

        //m_HandNoise = new Vector3(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
        //m_HandNoise.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            //l_Desiredforward = new Vector3(0, 0, 1);
            m_DesiredForward = +1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //l_Desiredforward = new Vector3(0, 0, -1);
            m_DesiredForward = -1;
        }
        else if(m_DesiredForward > 0)
        {
            m_DesiredForward -= 1.0f * Time.deltaTime;
            if(m_DesiredForward <= 0)
            {
                m_DesiredForward = 0;
            }
        }
        else if(m_DesiredForward  < 0)
        {
            m_DesiredForward += 1.0f * Time.deltaTime;
            if (m_DesiredForward >= 0)
            {
                m_DesiredForward = 0;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            //l_Desiredforward = new Vector3(-1, 0, 0);
            m_DesiredRight = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //l_Desiredforward = new Vector3(1, 0, 0);
            m_DesiredRight = +1;

        }
        else if (m_DesiredRight > 0)
        {
            m_DesiredRight -= 1.0f * Time.deltaTime;
            if (m_DesiredRight <= 0)
            {
                m_DesiredRight = 0;
            }
        }
        else if (m_DesiredRight < 0)
        {
            m_DesiredRight += 1.0f * Time.deltaTime;
            if (m_DesiredRight >= 0)
            {
                m_DesiredRight = 0;
            }
        }
        //l_Desiredforward.Normalize();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            m_Speed += m_Acceleration * Time.deltaTime;
        }
        else
        {
            m_Speed = m_BaseSpeed;
        }
        /*if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            m_Speed = m_BaseSpeed;
        }*/

        if (m_Speed > m_MaxSpeed)
            m_Speed = m_MaxSpeed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Rotation += new Vector3(-m_AngularSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Rotation += new Vector3(m_AngularSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Rotation += new Vector3(0, -m_AngularSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Rotation += new Vector3(0, m_AngularSpeed, 0);
        }

        //transform.rotation = Quaternion.Euler(m_Rotation.x, m_Rotation.y, 0.0f);
        //transform.position = transform.position + l_Desiredforward * m_Speed * Time.deltaTime;

        //m_PlayerPosition += transform.forward * l_DesiredForward * m_Speed * Time.deltaTime;
        //m_PlayerPosition += transform.right * l_DesiredRight * m_Speed * Time.deltaTime;

        //if (m_NoiseCounter >= m_NoiseCounterMaxTime)
        //{
        //    m_PlayerPosition += (m_HandNoise * m_MaxNoise) * m_Speed * Time.deltaTime;
        //    m_NoiseCounter = 0;
        //}
        //else
        //{
        Vector3 m_Direction = transform.forward * m_DesiredForward;
        m_Direction += transform.right * m_DesiredRight;
        m_Direction.Normalize();
        Debug.Log(m_Direction);
        Debug.Log("Speed: "+m_Speed);
        m_PlayerPosition += m_Direction * m_Speed * Time.deltaTime;
            //m_NoiseCounter += 1.0f * Time.deltaTime;
        //}

        m_RigidBody.Move(m_PlayerPosition, Quaternion.Euler(m_Rotation.x, m_Rotation.y, 0.0f));
    }

    public void RestartGame()
    {
        Debug.Log("Player restart");
        transform.position = m_StartPosition;
        transform.rotation = m_StartRotation;
        m_PlayerPosition = m_StartPosition;
        m_Rotation = m_StartRotation.eulerAngles;
    }
}
