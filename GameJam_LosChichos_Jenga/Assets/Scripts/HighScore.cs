using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public GameController m_GameController;
    public GameObject value;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
