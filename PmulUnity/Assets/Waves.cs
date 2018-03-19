
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;

    [SerializeField]
    private float timeWaves;

    private Interface wavesInterface;
    private int actualWave;
    private int actualMob;
    private float[] timeSpawns;
    private float timeWavesSave;
    void Start()
    {
        wavesInterface = GameObject.Find("GameManager").GetComponent<Interface>();
        wavesInterface.waveLenght = waves.Length;
        wavesInterface.Wave = 1;
        actualWave = 0;
        actualMob = 0;
        int i = 0;
        timeWavesSave = timeWaves;
        timeSpawns = new float[waves.Length];
        foreach (Wave w in waves)
        {
            timeSpawns[i] = w.timeSpawn;
            i++;
        }
    }


    void Update()
    {      
        if (actualWave < waves.Length)
        {           
            if (actualMob < waves[actualWave].enemys.Length)
            {
                waves[actualWave].timeSpawn -= Time.deltaTime;
                if (waves[actualWave].timeSpawn < 0)
                {
                    Instantiate(waves[actualWave].enemys[actualMob++]).transform.position = transform.position;
                    waves[actualWave].timeSpawn = timeSpawns[actualWave];
                }
            }
            else
            {
                timeWaves -= Time.deltaTime;
                if (timeWaves < 0)
                {
                    wavesInterface.Wave++;
                    timeWaves = timeWavesSave;
                    actualMob = 0;
                    actualWave++;
                }
            }
        }

    }

    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemys;
        public float timeSpawn;
    }
}
