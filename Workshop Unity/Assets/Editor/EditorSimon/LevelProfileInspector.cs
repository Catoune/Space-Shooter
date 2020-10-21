using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(MyLevelProfile))]
public class LevelProfileInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Open Editor"))
            MyFirstWindow.InitWithContent(target as MyLevelProfile);
    }
}
