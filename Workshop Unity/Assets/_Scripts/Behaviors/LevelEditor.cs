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

    public Color colorObstacle;

    public string name = string.Empty;
    public GameObject[,] levelValues = new GameObject[lineNumber, columnsNumber];

    public string[] existingName = new string[30];

    public Material saveMat;

    public int increment = 01;

    public void SetArrayElement(int x, int y)
    {
        GameObject go = Instantiate(Resources.Load("Obstacle", typeof(GameObject))) as GameObject;
        GameObject goClone = go.gameObject;
        CreateNewMaterials(goClone);
        goClone.transform.position = new Vector3(y+1, x+1, 1f);
        levelValues[x, y] = goClone;
    }

    public void RemoveArrayElement(int x, int y)
    {
        DestroyImmediate(levelValues[x, y]);
    }

    public void CreateNewMaterials(GameObject go)
    {
        Material newMat = Instantiate(go.GetComponent<MeshRenderer>().material);
        newMat.color = colorObstacle;
        go.GetComponent<MeshRenderer>().material = newMat;

        string uniqueName = ObjectNames.GetUniqueName(existingName, go.name);
        
        for(int i = 0; i < existingName.Length; i++)
        {
            if(existingName[i] == string.Empty)
            {
                existingName[i] = uniqueName;
            }
        }

        string localPath = "Assets/Resources/Materials/" + uniqueName + increment.ToString() + ".mat";
        AssetDatabase.CreateAsset(newMat, localPath);
        saveMat = newMat;
        increment++;
        AssetDatabase.SaveAssets();
    }

    public void SaveThisLevel(string name)
    {
        GameObject level = new GameObject();
        level.name = name;

        foreach (GameObject go in levelValues)
        {
            if (go != null)
            {
                go.transform.SetParent(level.transform);
                go.GetComponent<MeshRenderer>().material = saveMat;
            }
        }

        level.AddComponent<ObstacleBehavior>();
        level.GetComponent<ObstacleBehavior>().isUse = false;

        string localPath = "Assets/Resources/Prefab/Levels/" + level.name + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(level, localPath, InteractionMode.UserAction);

        ObstacleManager.SaveInObstacleList(name);

        DestroyImmediate(level);
    }
}
