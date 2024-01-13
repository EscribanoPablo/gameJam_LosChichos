using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_Speed = 5.0f;
    

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 l_Desiredforward = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            l_Desiredforward = new Vector3(0, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            l_Desiredforward = new Vector3(0, 0, -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            l_Desiredforward = new Vector3(1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            l_Desiredforward = new Vector3(-1, 0, 0);
        }

        transform.position = transform.position + l_Desiredforward * m_Speed * Time.deltaTime;
    }
}
