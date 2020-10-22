using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MyFirstWindow : EditorWindow
{
    MyLevelProfile currentProfile;


    [MenuItem("Window/MyFirstWindow %&#w")]
    public static void Init()
    {
        MyFirstWindow window = EditorWindow.GetWindow(typeof(MyFirstWindow)) as MyFirstWindow;

        //Initialize window

        window.Show();
    }

    public static void InitWithContent(MyLevelProfile profile)
    {
        MyFirstWindow window = EditorWindow.GetWindow(typeof(MyFirstWindow)) as MyFirstWindow;

        window.currentProfile = profile;

        window.Show();
        window.position = new Rect(50, 50, 300, 500);
    }

    public void OnGUI()
    {
        if (currentProfile == null)
        {
            EditorGUILayout.LabelField("Currently displayed Profile is Null ");
            return;
        }

        if (currentProfile.levelValues.Length > 0)
        {
            float tileWidth = 50f;
            float tileHeight = 50f;
            float tileSpace = 1.1f;

            int rowAmount = 2;
            int columnAmount = 2;

            Event cur = Event.current;

            for(int i = 0; i < currentProfile.levelValues.Length; i++)
            {
                Rect squareRect = new Rect(30 + (tileWidth * tileSpace) * i, 30, tileWidth, tileHeight);

                EditorGUIUtility.AddCursorRect(squareRect, MouseCursor.Arrow);

                if(squareRect.Contains(cur.mousePosition))
                {
                    EditorGUI.DrawRect(squareRect, Color.blue);
                }
                else
                {
                    EditorGUI.DrawRect(squareRect, Color.green);
                }

                Repaint();
            }

            float x = this.position.width;
            float y = this.position.height;


            Rect jsonButtonRect = new Rect(x * .1f, y * .2f, x*.6f, y*.3f);
            if(GUI.Button(jsonButtonRect, "Export as JSON"))
            {
                string curveAsJson = JsonUtility.ToJson(currentProfile, true);
                string filePath = "Assets/myFirstCurve.json";
                File.WriteAllText(filePath, curveAsJson);
            }
        }


        /*EditorGUI.DrawRect(new Rect(30, 30, 100, 100), Color.green);

        Rect pos = this.position;
        float x = pos.width;
        float y = pos.height;

        Rect closeButtonRect = new Rect(x*0.1f, y*0.2f, x*0.6f, y*0.3f);
        if (GUI.Button(closeButtonRect, "Close"))
            this.Close();*/
    }

    public void OnOldGUI()
    {

    }
}
