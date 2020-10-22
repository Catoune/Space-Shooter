using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;

[CustomEditor(typeof(LevelEditor))]

public class LevelEditorInspector : Editor
{
    LevelEditor currentProfile;

    SerializedProperty valuesDoubleTab;
    SerializedProperty stringName;
    SerializedProperty line;
    SerializedProperty column;
    public Color[,] colorList = new Color[9,9];

    private void OnEnable()
    {
        stringName = serializedObject.FindProperty(nameof(LevelEditor.name));
        
        for(int i = 0; i < LevelEditor.columnsNumber; i++)
        {
            for (int j = 0; j < LevelEditor.lineNumber; j++)
            {
                colorList[i,j] = Color.red;
            }
        }
    }

    private void OnDisable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        //GUIStyle buttonsMenu = new GUIStyle("MeTimeLabel");

        Color oldColor = GUI.color;
        Event cur = Event.current;
        GUI.color = Color.red;

        for (int i = 0; i < LevelEditor.columnsNumber; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < LevelEditor.lineNumber; j++)
            {
                GUI.color = colorList[i, j];
                
                    if (GUILayout.Button(""))
                    {
                        if (colorList[i, j] == Color.red)
                        {
                            colorList[i, j] = Color.green;
                            (target as LevelEditor).SetArrayElement(i, j);
                        }
                        else
                        {
                            colorList[i, j] = Color.red;
                            (target as LevelEditor).RemoveArrayElement(i, j);
                        }
                    }
                
            }
            EditorGUILayout.EndHorizontal();
        }

        GUI.color = oldColor;

        if (GUILayout.Button("Genererate Level"))
        {

        }
    }

    static bool IsMouseOver()
    {
        return Event.current.type == EventType.MouseDown && GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition);
    }
}
