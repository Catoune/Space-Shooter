using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyCustomSettingProvider : SettingsProvider
{
    static Editor myCustomSettingEditor;


    public MyCustomSettingProvider(string path, SettingsScope scope = SettingsScope.Project) : base (path, scope)
    {

    }

    [SettingsProvider]
    public static SettingsProvider CreateProvider()
    {
        MyCustomSettingProvider mySP = new MyCustomSettingProvider("Project My Custom Stuff", SettingsScope.Project);

        //MyCustomSetting mcs = Resources.Load("My Settings") as MyCustomSetting;

        mySP.guiHandler += OnProviderGUI;
            
        /*(string SearchBarContent) =>
        {
            EditorGUILayout.LabelField(SearchBarContent);
            EditorGUILayout.LabelField("Hello World");
        };*/


        return mySP;
    }

    static void OnProviderGUI(string searchBarContent)
    {
        MyCustomSetting mcs = Resources.Load("My Settings") as MyCustomSetting;

        if(myCustomSettingEditor)
        {
            Editor.CreateCachedEditor(mcs, null, ref myCustomSettingEditor);
        }
        //myCustomSettingEditor.OnInspectorGUI();
    }

}
