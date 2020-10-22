using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.UIElements;

[CustomEditor(typeof(SomeCommonComponent))]
public class SomeCommonComponentInspector : Editor
{
    SerializedProperty myProp;
    SerializedProperty forkProperty;

    ReorderableList rList;
    SerializedProperty myArrayProperty;
    GenericMenu gm;

    private void OnEnable()
    {
        myArrayProperty = serializedObject.FindProperty(nameof(SomeCommonComponent.myArray));

        rList = new ReorderableList(serializedObject, myArrayProperty, true, true, true, true);
        rList = SetupList(rList);

        gm = new GenericMenu();
        gm = SetupMenu(gm);
    }


    public ReorderableList SetupList(ReorderableList emptyList)
    {
        // do stuff

        emptyList.drawHeaderCallback += DrawMyListHeader;
        emptyList.drawElementCallback += DrawMyListElement;
        emptyList.onReorderCallback += MyListHasBeenReordered;
        emptyList.onAddCallback += MyListAddCallback;
        emptyList.onRemoveCallback += MyListRemoveCallback;
        emptyList.elementHeightCallback += GetArrayElementHeight;

        return emptyList;
    }

    public GenericMenu SetupMenu(GenericMenu gm)
    {
        gm.AddItem(new GUIContent("Première Option"), false, SimpleCallback);
        gm.AddDisabledItem(new GUIContent("Seconde Option"));
        gm.AddSeparator("");
        gm.AddItem(new GUIContent("Troisième Option"), false, SimpleCallback);
        gm.AddItem(new GUIContent("Autres Options/Quatrième Option"), false, SimpleCallback);
        gm.AddSeparator("Autres Options/");
        gm.AddItem(new GUIContent("Autres Options/Cinquième Option"), false, SimpleCallback);

        return gm;
    }

    void SimpleCallback()
    {

    }

    void DrawMyListHeader(Rect rect)
    {
        EditorGUI.LabelField(rect, "Ceci est mon header de lists");
    }

    void DrawMyListElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty elementProp = myArrayProperty.GetArrayElementAtIndex(index);
        EditorGUI.PropertyField(rect, elementProp);
    }

    void MyListHasBeenReordered(ReorderableList list)
    {

    }

    void MyListAddCallback(ReorderableList list)
    {
        myArrayProperty.arraySize++;
    }
    void MyListRemoveCallback(ReorderableList list)
    {
        Debug.Log("Element supr. à l'index : " + list.index.ToString());
        myArrayProperty.DeleteArrayElementAtIndex(list.index);
    }

    float GetArrayElementHeight(int index)
    {
        return (float)(index + 1) * (EditorGUIUtility.singleLineHeight + 1);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        rList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();

        if(GUILayout.Button("Display sub Menu"))
        {
            gm.ShowAsContext();
        }
    }

    /*
    private void OnEnable()
    {
        myProp = serializedObject.GetIterator();
       /* 
        myProp.NextVisible(true);
        Debug.Log(myProp.name);
        Debug.Log(myProp.displayName);
        Debug.Log(myProp.type);
       

        while (myProp.NextVisible(true))
        {
            Debug.Log(myProp.name);
            Debug.Log(myProp.displayName);
            Debug.Log(myProp.type);
            if(myProp.type == "Color")
            {
                forkProperty = myProp.Copy();
            }
        }
        myProp.Reset();
    }*/

    /*public override void OnInspectorGUI()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        base.OnInspectorGUI();

        sw.Stop();
        EditorGUILayout.LabelField(sw.ElapsedTicks.ToString());
    }*/
}