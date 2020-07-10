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
    
    //current
    public float currentGlobalSpeed = 60f;
    public float currentScore = 0f;
    public float currentRespawnTime = 0.3f;//= 0.3f;


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

    void Update() {
        
        if (currentRespawnTime > minRespawnTime) {
            //리스폰 주기 점점 감소
            //currentRespawnTime-=increasePerTimeRespawnTime;
        }
    }

    public void ResetGlobalSpeed() {
        currentGlobalSpeed = 0f;
    }
}