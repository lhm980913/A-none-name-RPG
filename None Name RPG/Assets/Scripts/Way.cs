using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : ScriptableObject
{

    public List<Vector2Int> Path;

    public Way()
    {
        Path = new List<Vector2Int>();
    }

}
