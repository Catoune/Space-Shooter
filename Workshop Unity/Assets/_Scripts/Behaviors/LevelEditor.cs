using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(fileName = "New Level File.asset", menuName = "LevelEditor/New Level File", order = 7)]
public class LevelEditor : ScriptableObject
{
    public static int lineNumber = 9;
    public static int columnsNumber = 9;

    public string name = string.Empty;
    public GameObject[,] levelValues = new GameObject[lineNumber, columnsNumber];

    public void SetArrayElement(int x, int y)
    {
        GameObject go = Instantiate(Resources.Load("Obstacle", typeof(GameObject))) as GameObject;
        GameObject goClone = go.gameObject;
        goClone.transform.position = new Vector3(y+1, x+1, 1f);
        levelValues[x, y] = goClone;
    }

    public void RemoveArrayElement(int x, int y)
    {
        DestroyImmediate(levelValues[x, y]);
    }

    public void SaveThisLevel(string name)
    {
        GameObject level = new GameObject();
        level.name = name;

        foreach(GameObject go in levelValues)
        {
            if (go != null)
            {
                go.transform.SetParent(level.transform);
            }
        }

        string localPath = "Assets/Prefab/Levels/" + level.name + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(level, localPath, InteractionMode.UserAction);
    }
}
