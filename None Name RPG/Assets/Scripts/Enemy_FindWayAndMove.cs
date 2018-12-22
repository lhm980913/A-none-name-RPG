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
    private float dis;

    // Use this for initialization
    private void Awake()
    {
        if (path != null)
        {
            transform.position = path.way[0];
        }
        //Debug.Log("" + transform.position);
        count = 0;
        loop = 0;
        dis = 0;
    }

    void Start () {
        
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
        if (loop > 1 && count < path.way.Count -1)
        {
            //Debug.Log("next:" + count + " last:" + (count - 1));
            last = path.way[count];
            next = path.way[count+1];
            dis = Vector3.Distance(last, next);
            count++;
            loop = 0;
        }
        loop += (Speed * Time.deltaTime / dis);
        transform.position = Vector3.Lerp(last,next, loop);
    }

    public void SetPath(PathAsset pathasset)
    {
        path = pathasset;
    }
    
}
