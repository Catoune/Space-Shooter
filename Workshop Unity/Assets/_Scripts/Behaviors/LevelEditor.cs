using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level File.asset", menuName = "LevelEditor/New Level File", order = 7)]
public class LevelEditor : ScriptableObject
{
    public static int lineNumber = 9;
    public static int columnsNumber = 9;

    public string name = string.Empty;
    public GameObject[,] levelValues = new GameObject[columnsNumber,lineNumber];

    public void SetArrayElement(int x, int y)
    {
        GameObject go = GameObject.Instantiate(Resources.Load("Obstacle", typeof(GameObject))) as GameObject;
        go.transform.position = new Vector3(x+1, y+1, 1f);
        levelValues[x, y] = go;
    }

    public void RemoveArrayElement(int x, int y)
    {
        DestroyImmediate(levelValues[x, y]);
    }
}
