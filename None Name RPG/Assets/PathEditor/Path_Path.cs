using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Path_Path : MonoBehaviour {

    public List<Vector3> Points;

	// Use this for initialization
	void Start () {
        Points = new List<Vector3>();
	}

    private void OnDrawGizmos()
    {
        if (Points.Count >= 2)
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                Gizmos.DrawLine(Points[i], Points[i + 1]);
            }
            foreach (var p in Points)
            {
                Gizmos.DrawSphere(p, 1);
            }
        }
    }
    
}
