using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FindWayAndMove : MonoBehaviour {

    public Way way;
    public float UintScale = 1;

    public float Speed;
    public float turnTime;
    private Vector3 last;
    private Vector3 next;
    private Vector3 lastDir;
    private int count;
    private float loop;

	// Use this for initialization
	void Start () {
        transform.position = GetPos(way.Path[0],10);
        count = 0;
        last = GetPos(way.Path[count]);
        next = GetPos(way.Path[count + 1]);
        loop = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(count < way.Path.Count    )
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
        transform.forward = next - last;
    }
    
    void Move()
    {
        if (Vector3.Distance(transform.position,next) < 1 && count < way.Path.Count-1)
        {
            //Debug.Log("next:" + count + " last:" + (count - 1));
            last = GetPos(way.Path[count]);
            next = GetPos(way.Path[count+1]);
            count++;
            loop = 0;
        }
        loop += Speed * Time.deltaTime;
        transform.position = Vector3.Lerp(last, next, loop);
        //transform.Translate(next - last);
        //GetComponent<Rigidbody>().velocity = (next - last).normalized * Speed;
    }

    Vector3 GetPos(Vector2Int pos)
    {
        //Debug.Log("" + transform.position.y);
        return UintScale * new Vector3(pos.x - 65, transform.position.y , pos.y - 41);
    }

    Vector3 GetPos(Vector2Int pos, float y)
    {
        return UintScale * new Vector3(pos.x - 65, y, pos.y - 41);
    }

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(0, 0, 200, 200), "next:" + next + "\nlast:" + last);
    //}
}
