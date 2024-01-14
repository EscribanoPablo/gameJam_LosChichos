using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    bool sameFound;
    void Start()
    {
        foreach (GameObject musiqueja in GameObject.FindGameObjectsWithTag("Musiqueja"))
        {
            if (musiqueja != this.gameObject)
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
