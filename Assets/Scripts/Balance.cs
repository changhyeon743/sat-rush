using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance: MonoBehaviour
{
    public static Balance instance = null;

    public float maxGlobalSpeed = 400f;
    public float minRespawnTime = 0.05f;
    public float increasePerTimeGlobalSpeed = 0.3f;
    public float increasePerTimeRespawnTime = 0.01f;



    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);    
        }   
        DontDestroyOnLoad(gameObject);
    }
}