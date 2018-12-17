using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAsset : ScriptableObject {

    public List<Vector3> way;

    public PathAsset()
    {
        way = new List<Vector3>();
    }
}
