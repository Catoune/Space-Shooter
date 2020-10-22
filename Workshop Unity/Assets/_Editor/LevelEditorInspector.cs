using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;

[CustomEditor(typeof(LevelEditor))]

public class LevelEditorInspector : Editor
{
    LevelEditor currentProfile;

    public Color[,] colorList = new Color[LevelEditor.lineNumber, LevelEditor.columnsNumber];

    public string name;

    private void OnEnable()
    {
        currentProfile = (target as LevelEditor);

        for (int i = 0; i < LevelEditor.lineNumber; i++)
        {
            for (int j = 0; j < LevelEditor.columnsNumber; j++)
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
        //Event cur = Event.current;
        //GUI.color = Color.red;

        for (int i = LevelEditor.lineNumber-1; i >= 0; i--)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < LevelEditor.columnsNumber; j++)
            {
                GUI.color = colorList[i, j];
                
                    if (GUILayout.Button(""))
                    {
                        if (colorList[i, j] == Color.red)
                        {
                            colorList[i, j] = Color.green;
                            currentProfile.SetArrayElement(i, j);
                        }
                        else
                        {
                            colorList[i, j] = Color.red;
                            currentProfile.RemoveArrayElement(i, j);
                        }
                    }
                
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.BeginHorizontal();
        GUI.color = oldColor;

        name = EditorGUILayout.TextField("Level Name:", name);

        GUI.enabled = false;
        if (name != null)
        {
            if (name.Length > 0)
            {
                GUI.enabled = true;
            }
        }

        if (GUILayout.Button("Save this level"))
        {
            currentProfile.SaveThisLevel(name);
        }

        EditorGUILayout.EndHorizontal();
    }

    static bool IsMouseOver()
    {
        return Event.current.type == EventType.MouseDown && GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition);
    }
}
