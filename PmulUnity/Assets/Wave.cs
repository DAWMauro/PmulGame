using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemys;
    [SerializeField]
    private float timeSpawn;

    private float originalTimeSpawn;
    private int mobs;
    private int actualMob;

    void Start()
    {
        originalTimeSpawn = timeSpawn;
        mobs = enemys.Length - 1;
        actualMob = 1;
        Instantiate(enemys[0]).transform.position = transform.position;
    }


    void Update()
    {
        if (mobs > 0)
        {
            timeSpawn -= Time.deltaTime;
            if (timeSpawn < 0)
            {
                Instantiate(enemys[actualMob++]).transform.position = transform.position;
                --mobs;
                timeSpawn = originalTimeSpawn;
            }
        }
    }
}
