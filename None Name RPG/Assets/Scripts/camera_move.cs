using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
        {
            this.transform.localPosition += this.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.localPosition -= this.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.localPosition -= this.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.localPosition += this.transform.right;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.localPosition += Vector3.up;
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.localPosition -= Vector3.up;
        }


    }
}
