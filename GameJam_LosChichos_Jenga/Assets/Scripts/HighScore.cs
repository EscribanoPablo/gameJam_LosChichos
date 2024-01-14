using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public int value;
    bool sameFound;

    void Start()
    {
        foreach (GameObject highScore in GameObject.FindGameObjectsWithTag("HighScore"))
        {
            if (highScore != this.gameObject)
            {
                sameFound = true;
            }
        }

        if (sameFound)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
}
