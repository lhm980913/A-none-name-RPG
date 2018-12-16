using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapEditor : EditorWindow {

    Texture2D tex;
    Vector2Int start;
    Vector2Int end;
    
    [MenuItem("Window/Map Editor")]
    static void showWindow()
    {
        MapEditor editor = (MapEditor)EditorWindow.GetWindow(typeof(MapEditor), false, "Map Editor", true);
        editor.Show();
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical();

        GUILayout.Space(10);
        tex = (Texture2D)EditorGUILayout.ObjectField(tex, typeof(Texture2D),false);
        start = (Vector2Int)EditorGUILayout.Vector2IntField("StartPoint", start);
        end = (Vector2Int)EditorGUILayout.Vector2IntField("EndPoint", end);
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        if(GUILayout.Button("生成Path"))
        {
            if (tex != null)
            {
                Map.CreatePath(tex,start,end);
                this.RemoveNotification();
            }
            else
                this.ShowNotification(new GUIContent("There is no Texture"));
        }
        GUILayout.EndVertical();
    }

}
