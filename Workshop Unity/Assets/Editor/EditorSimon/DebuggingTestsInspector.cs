using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(DebuggingTests))]
public class DebuggingTestsInspector : Editor
{
    SerializedProperty oneFirstCamera, oneSecondCamera;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        oneFirstCamera = serializedObject.FindProperty(nameof(DebuggingTests.oneFirstCamera));
        oneSecondCamera = serializedObject.FindProperty(nameof(DebuggingTests.oneSecondCamera));

        serializedObject.ApplyModifiedProperties();
    }
}
