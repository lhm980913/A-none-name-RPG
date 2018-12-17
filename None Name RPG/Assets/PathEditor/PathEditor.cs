using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor {

    Path path;

    public PathAsset pa;

    private int selectedIndex = -1;

    private void OnEnable()
    {
        path = (Path)target;
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        pa = (PathAsset)EditorGUILayout.ObjectField(pa,typeof(PathAsset),false);
        if (pa != null)
        {
            path.Points = pa.way;
        }
        if (GUILayout.Button("Finsh"))
        {
            CreatePath();
        }
    }

    private void CreatePath()
    {
        string AssetPath = "Assets/Path/Path.asset";
        PathAsset ps = ScriptableObject.CreateInstance<PathAsset>();
        ps.way = path.Points;
        UnityEditor.AssetDatabase.CreateAsset(ps, AssetPath);
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }


    private void OnSceneGUI()
    {
        for(int i = 0; i < path.Points.Count; i++)
        {
            ShowPoint(i);
        }
    }

    private void ShowPoint(int index)
    {
        Vector3 point = path.Points[index];
        Handles.color = Color.white;
        if (Handles.Button(point, Quaternion.identity, 0.04f, 0.08f, Handles.DotHandleCap))
        {
            selectedIndex = index;
        }
        if(selectedIndex == index)
        {
            EditorGUI.BeginChangeCheck();
            path.Points[index] = Handles.PositionHandle(path.Points[index], Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(path, "Move Point");
                EditorUtility.SetDirty(path);
                
            }
        }
    }

}
