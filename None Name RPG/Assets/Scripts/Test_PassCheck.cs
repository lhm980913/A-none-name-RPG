using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PassCheck : MonoBehaviour {
    public Way way;
    public GameObject oj;
    public float Uint = 1;
	// Use this for initialization
	void Start () {
        GameObject go;
        foreach (var item in way.Path)
        {
            Vector2Int pop = item;
            go = Instantiate(oj, Uint * new Vector3(pop.x, 0, pop.y), Quaternion.Euler(0, 0, 0));
            go.transform.localScale = new Vector3(Uint, 1, Uint);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
