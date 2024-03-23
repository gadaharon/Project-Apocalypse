using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    public static ScenePersist Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        // int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
        // if (numScenePersist > 1)
        // {
        //     ResetScenePersist();
        // }
        // else
        // {
        //     DontDestroyOnLoad(gameObject);
        // }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
