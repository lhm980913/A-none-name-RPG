﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_MapManager : MonoBehaviour {
    
    public GameObject WaveManager_1;
    public GameObject WaveManager_2;
    public GameObject WaveManager_3;
    public GameObject WaveManager_4;

    Manager_WaveManager[] waveManagers;

    delegate void waveControll(int i);
    event waveControll WaveStart;

    private int wave;

	// Use this for initialization
	void Start () {
        //Initialize WaveManagers
        waveManagers = new Manager_WaveManager[4];
        waveManagers[0] = WaveManager_1.GetComponent<Manager_WaveManager>();
        waveManagers[1] = WaveManager_2.GetComponent<Manager_WaveManager>();
        waveManagers[2] = WaveManager_3.GetComponent<Manager_WaveManager>();
        waveManagers[3] = WaveManager_4.GetComponent<Manager_WaveManager>();

        for(int i = 0; i < 4; i++)
        {
            WaveStart += waveManagers[i].WaveStart;
        }

        wave = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            testWave();
        }
	}

    void testWave()
    {
        for(int i = 0; i < 4; i++)
        {
            if(waveManagers[i].waveAsset.waves.Count > wave)
            {
                StartWave(wave);
                wave++;
            }
        }
    }

    void StartWave(int index)
    {
        WaveStart(index);
    }

    void GameOver()
    {

    }

}
