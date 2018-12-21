using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FindWayAndMove : MonoBehaviour {

    public float Speed;
    public float turnTime;
    private Vector3 last;
    private Vector3 next;
    private Vector3 lastDir;
    private int count;
    private float loop;
    private PathAsset path;

    // Use this for initialization
    void Start () {
        if(path != null)
        {
            transform.position = path.way[0];
        }
        Debug.Log("" + transform.position);
        count = 0;
        loop = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(path != null && count < path.way.Count)
        {
            Move();
            TurnAround();
        }
        else
        {

        }
	}

    void TurnAround()
    {
        if(next - last != Vector3.zero)
        {
            transform.forward = next - last;
        }
        
    }
    
    void Move()
    {
        if (Vector3.Distance(transform.position,next) < 0.01 && count < path.way.Count -1)
        {
            //Debug.Log("next:" + count + " last:" + (count - 1));
            last = path.way[count];
            next = path.way[count+1];
            count++;
            loop = 0;
        }
        loop += Speed * Time.deltaTime;
        transform.position = Vector3.Lerp(last,next, loop);
    }

    public void SetPath(PathAsset pathasset)
    {
        path = pathasset;
    }
    
}
