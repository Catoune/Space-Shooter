using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(MyHeavyGameplayScript))]
[CanEditMultipleObjects]
public class MyHeavyGameplayInspector : Editor
{
    MyHeavyGameplayScript myTargetScript;
    MyHeavyGameplayScript[] myTargetScripts;

    public void OnEnable()
    {
        myTargetScript = target as MyHeavyGameplayScript;

        for (int i = 0; i < targets.Length; i++)
        {
            myTargetScripts[i] = targets[i] as MyHeavyGameplayScript;
        }

        Undo.undoRedoPerformed += RecalculateStuffAfterUndo;
    }

    public void RecalculateStuffAfterUndo()
    {

    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        GUILayout.BeginVertical();

        EditorGUILayout.LabelField(EditorGUIUtility.labelWidth.ToString());

        #region INDENTATION
        int oldIndent = EditorGUI.indentLevel;
        //EditorGUI.indentLevel += 2;                                                                 //Espace avant "Ma couleur"
        float oldLabelWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth *= .5f;                                                           //Espace entre "Ma couleur" et la Color.barre
        myTargetScript.color = EditorGUILayout.ColorField("Ma couleur", myTargetScript.color);
        EditorGUI.indentLevel = oldIndent;
        #endregion

        #region OPTIONS
        string[] options = new string[] { "Option 1", "Option 2", "Option 3" };
        myTargetScript.enumExemple = (WrapMode)EditorGUILayout.Popup((int)myTargetScript.enumExemple, options);
        #endregion

        #region HELPBOX
        EditorGUILayout.HelpBox("Touche pas à ça, couillon ! ", MessageType.Error);
        #endregion

        #region CHANGECHECK
        EditorGUI.BeginChangeCheck();                                                                                                                      //Pas Layout car Layout utilisé surtout pour placement spatial
        Transform transformResult = EditorGUILayout.ObjectField("Self Transform", myTargetScript.selfTransform, typeof(Transform), true) as Transform;
        bool userChangeSomething = EditorGUI.EndChangeCheck();
        if(userChangeSomething)
        {
            Debug.Log("Something changed");
            Undo.RecordObject(myTargetScript, "Set Object Transform");
            myTargetScript.selfTransform = transformResult;
        }
        #endregion

        #region Boutton

        Color defColor = GUI.color;
        GUI.color = Color.green;

        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Auto Set Reference"))
        {
            AutoSetReference();
        }
        if (GUILayout.Button("Set Everything to Null"))
        {
            SetReferenceToNull();
        }
        GUILayout.EndHorizontal();

        #endregion

        #region FOLDOUT
        myTargetScript.foldoutState = EditorGUILayout.Foldout(myTargetScript.foldoutState, "Deplier ici", true);
        if(myTargetScript.foldoutState)
        {
            EditorGUILayout.LabelField("Hello World");
        }
        #endregion

        GUILayout.EndVertical();

        EditorUtility.SetDirty(myTargetScript);
        //EditorSceneManager.MarkAllScenesDirty();
    }

    void AutoSetReference()
    {
        Undo.RecordObject(myTargetScript, "Just Set Reference");

        myTargetScript.audioListener = Object.FindObjectOfType<AudioListener>();
        myTargetScript.myCamera = Object.FindObjectOfType<Camera>();
        myTargetScript.selfTransform = myTargetScript.transform;
        myTargetScript.camTransform = myTargetScript.myCamera.transform;
    }

    void SetReferenceToNull()
    {
        Undo.RecordObject(myTargetScript, "Just Null References");

        myTargetScript.audioListener = null;
        myTargetScript.myCamera = null;
        myTargetScript.selfTransform = null;
        myTargetScript.camTransform = null;
    }

    public void OnDisable()
    {
        Undo.undoRedoPerformed -= RecalculateStuffAfterUndo;
    }
}
