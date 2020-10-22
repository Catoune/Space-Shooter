using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnnemyProfile))]
public class MyStructDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //SerializedProperty colorProp = property.FindPropertyRelative(nameof(EnnemyProfile.color));
        //SerializedProperty redProp = colorProp.FindPropertyRelative("r");

        float numberOfLines = 2f;
        float lineSpace = 2f;

        if (EditorGUIUtility.currentViewWidth < 332)
        {
            numberOfLines++;
        }

        /*if (redProp.floatValue > 0.5f)
         {
             numberOfLines++;
         }
        */

        return numberOfLines * (EditorGUIUtility.singleLineHeight + lineSpace);
    }

    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        Rect colorRect = new Rect(rect.x, rect.y, rect.width * 0.5f, EditorGUIUtility.singleLineHeight);
        Rect speedRect = new Rect(rect.x + rect.width * 0.5f, rect.y,  rect.width * 0.5f, EditorGUIUtility.singleLineHeight);
        Rect spawnRect = new Rect(rect.x, rect.y + EditorGUIUtility.singleLineHeight + 2,  rect.width, EditorGUIUtility.singleLineHeight);

        //EditorGUI.DrawRect(colorRect, Color.yellow);
        //EditorGUI.DrawRect(speedRect, Color.cyan);

        SerializedProperty colorProp = property.FindPropertyRelative(nameof(EnnemyProfile.color));
        SerializedProperty speedProp = property.FindPropertyRelative(nameof(EnnemyProfile.speed));
        SerializedProperty spawnProp = property.FindPropertyRelative(nameof(EnnemyProfile.spawnPosition));

        float oldWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth *= 0.5f;
        EditorGUI.PropertyField(colorRect, colorProp);
        EditorGUI.PropertyField(speedRect, speedProp);
        EditorGUIUtility.labelWidth = oldWidth;

        EditorGUI.PropertyField(spawnRect , spawnProp);
    }
}
