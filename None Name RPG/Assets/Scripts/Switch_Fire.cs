﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Fire : MonoBehaviour {

    static public List<GameObject> Fire_Tower = new List<GameObject>();

    static public bool fire;

    // Use this for initialization
    void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Fire_Tower.Count);
		if(Input.GetKeyDown(KeyCode.K))
        {
            switch_on();
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            switch_off();
        }




    }

    void switch_on()
    {
        fire = true;
    }
    void switch_off()
    {
        fire = false;
    }
}
