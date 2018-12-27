using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class qupengzhuang : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
	}

    
	
	// Update is called once per frame
	void Update () {
		
	}
}

[CustomEditor(typeof(qupengzhuang))]
class qu : Editor
{
    public BoxCollider[] boxss;
    private Light[] lights;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var target = (qupengzhuang)(serializedObject.targetObject);
        if (GUILayout.Button("F"))
        {
            boxss = target.GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider child in boxss)
            {
                child.enabled = false;
            }
        }
    }
}
