using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Switch_Fire : MonoBehaviour {

    static public List<GameObject> Fire_Tower = new List<GameObject>();

    static public bool fire;


    public static float re_speed = 3;
    public static float energy_cost_speed = 0;
    public static float energy = 100;
    // Use this for initialization
    void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Fire_Tower.Count);
		if(Input.GetKeyDown(KeyCode.K) || SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            switch_on();
        }
        else if (Input.GetKeyUp(KeyCode.K) || SteamVR_Input._default.inActions.GrabPinch.GetStateUp(SteamVR_Input_Sources.LeftHand))
        {
            switch_off();
        }

        if(fire && energy>0)
        {
            energy -= Time.deltaTime * energy_cost_speed;
        }
        if(!fire && energy<100)
        {
            energy += Time.deltaTime * re_speed;
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
