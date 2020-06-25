using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SharedEvent))]
public class SharedEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var sharedEvent = (SharedEvent)target;

        if(GUILayout.Button("Raise Event"))
        {
            sharedEvent.Raise();
        }
    }
}
