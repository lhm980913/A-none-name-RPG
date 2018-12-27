using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Manager_MapManager : MonoBehaviour {
    
    public GameObject WaveManager_1;
    public GameObject WaveManager_2;

    Manager_WaveManager[] waveManagers;

    delegate void waveControll(int i);
    event waveControll WaveStart;

    private int wave;

	// Use this for initialization
	void Start () {
        //Initialize WaveManagers
        waveManagers = new Manager_WaveManager[2];
        waveManagers[0] = WaveManager_1.GetComponent<Manager_WaveManager>();
        waveManagers[1] = WaveManager_2.GetComponent<Manager_WaveManager>();

        for(int i = 0; i < 2; i++)
        {
            WaveStart += waveManagers[i].WaveStart;
        }

        wave = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)|| SteamVR_Input._default.inActions.menu.GetStateDown(SteamVR_Input_Sources.Any))
        {
            testWave();
        }
	}

    void testWave()
    {
        for(int i = 0; i < 2; i++)
        {
            if(waveManagers[i].waveAsset.waves.Count > wave)
            {
                StartWave(wave);
                //wave++;
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
