using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPersistence : MonoBehaviour
{
    private static PlayerPersistence instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // survives scene change
        }
        else
        {
            Destroy(gameObject); // prevents duplicates if new Player spawns
        }
    }
}
