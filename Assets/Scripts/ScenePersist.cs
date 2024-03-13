using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if (numScenePersist > 1)
        {
            ResetScenePersist();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
