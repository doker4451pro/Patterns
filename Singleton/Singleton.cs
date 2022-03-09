using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    private void Awake()
    {
        CheckForDuplicateAndSelfDestroy();
    }

    private void CheckForDuplicateAndSelfDestroy() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("Only one");
            Destroy(this);
        }
    }
}
