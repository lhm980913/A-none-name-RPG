﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Stab : MonoBehaviour {
    public static List<GameObject> Stab_Tower=new List<GameObject>();
    public static bool att = false;


   public  float time = 10;
    float CD = 10f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.J)&&time>0)
        {
            switch_on();
            time = 0;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            switch_off();
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            switch_off();
        }
    }
    void switch_on()
    {
        att = true;
    }
    void switch_off()
    {
        att = false;
    }
}
