using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObstacleManager))]
public class ObstacleManagerInspector : Editor
{
    ObstacleManager currentProfile;
    GUIStyle buttonsMenu;
    SerializedProperty listObs;

    private void OnEnable()
    {
        currentProfile = (target as ObstacleManager);
        currentProfile.obstaclePrepared = Object.FindObjectOfType<ObstacleParent>().transform;
        listObs = serializedObject.FindProperty("copyObstacleList");
    }

    public override void OnInspectorGUI()
    {
        Color oldColor = GUI.color;

        EditorGUILayout.PropertyField(listObs);

        if (ObstacleManager.isListRefreshed)
        {
            buttonsMenu = new GUIStyle("flow node hex 2");
            buttonsMenu.padding = new RectOffset(20, 20, 10, 10);
            buttonsMenu.margin = new RectOffset(0, 0, 5, 5);
        }
        else
        {
            buttonsMenu = new GUIStyle("flow node hex 6");
            buttonsMenu.padding = new RectOffset(20, 20, 10, 10);
            buttonsMenu.margin = new RectOffset(0, 0, 5, 5);
        }

        GUI.enabled = false;
        Transform transformResult = EditorGUILayout.ObjectField("Parent des Obstacles : ", currentProfile.obstaclePrepared, typeof(Transform), true) as Transform;
        GUI.enabled = true;

        GUILayout.BeginHorizontal();
        GUILayout.Space(15f);
        if (GUILayout.Button("Initialiser la liste à partir du Parent", buttonsMenu, GUILayout.MinWidth(EditorGUIUtility.currentViewWidth - 60)))
        {
            currentProfile.SetList();
        }
        GUILayout.Space(15f);
        GUILayout.EndHorizontal();

        GUI.color = oldColor;
    }
}

