using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;

[CustomEditor(typeof(MySecondGameplayScript))]
[CanEditMultipleObjects]
public class MySecondHeavyInspector : Editor
{
    SerializedProperty myColorProperty;
    SerializedProperty redLevel;
    SerializedProperty myStrings;
    SerializedProperty myEnnemyProfile;

    private void OnEnable()
    {
        myColorProperty = serializedObject.FindProperty(nameof(MySecondGameplayScript.myColor));
        redLevel = myColorProperty.FindPropertyRelative("r");

        myStrings = serializedObject.FindProperty(nameof(MySecondGameplayScript.myStrings));
        myEnnemyProfile = serializedObject.FindProperty(nameof(MySecondGameplayScript.myEnnemyProfile));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (GUILayout.Button("Jour"))
        {
            myColorProperty.colorValue = Color.yellow;
        }

        if (GUILayout.Button("Nuit"))
        {
            myColorProperty.colorValue = Color.black;
        }
        EditorGUILayout.PropertyField(myColorProperty);

        EditorGUILayout.LabelField(redLevel.floatValue.ToString());

        //EditorGUI.BeginChangeCheck();
        redLevel.floatValue = EditorGUILayout.Slider("Red", redLevel.floatValue, 0f, 1f);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add one")) myStrings.arraySize++;
        if (GUILayout.Button("Remove one")) myStrings.arraySize--;
        EditorGUILayout.EndHorizontal();

        if (myStrings.arraySize > 0)
        {
            for (int i = 0; i < myStrings.arraySize; i++)
            {
                EditorGUILayout.PropertyField(myStrings.GetArrayElementAtIndex(i),new GUIContent("Mon string", "Ceci est un tooltip"));
            }
        }

        EditorGUILayout.PropertyField(myEnnemyProfile);

        serializedObject.ApplyModifiedProperties();
        //serializedObject.ApplyModifiedPropertiesWithoutUndo();
        //base.OnInspectorGUI();
    }

    private void OnDisable()
    {
        
    }
}
