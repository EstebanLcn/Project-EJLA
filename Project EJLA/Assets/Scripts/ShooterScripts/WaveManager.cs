﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public WaveObjects[] waves;
    public int currentWave;
    public float timeToNextWave;
    public bool canSpwanWaves;
    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeToNextWave = waves[0].timeToSpawn;
     
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpwanWaves){

        
           timeToNextWave -= Time.deltaTime;
           if(timeToNextWave <= 0 )
           {
               Instantiate(waves[currentWave].theWave, transform.position, transform.rotation);
               if (currentWave < waves.Length -1)
               {
                    currentWave ++;
               timeToNextWave = waves[currentWave].timeToSpawn;
               }else{
                   canSpwanWaves = false;
               }
              
           }}
    }
    public void ContinueSpawning()
    {
        if(currentWave <= waves.Length - 1 && timeToNextWave > 0)
        {
            canSpwanWaves = true;
        }
    }
}
[System.Serializable]
public class WaveObjects
{
    public float timeToSpawn;
    public EnnemyWaves theWave;
}