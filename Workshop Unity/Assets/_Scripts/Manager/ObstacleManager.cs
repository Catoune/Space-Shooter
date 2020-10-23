using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;
    public static List<ObstacleBehavior> staticObstacleList = new List<ObstacleBehavior>();
    public List<ObstacleBehavior> copyObstacleList = new List<ObstacleBehavior>();
    public Transform obstaclePrepared;
    public static bool isListRefreshed = false;

    public float timer = 0f;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
        Debug.Log(instance);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 5f)
        {
            InstantiateObstacle();
            timer = 0f;
        }
    }

    private void Start()
    {
        //copyObstacleList = obstacleList;
    }

    public void InstantiateObstacle()
    {
        for(int i = 0; i < copyObstacleList.Count; i++)
        {
            if (!copyObstacleList[i].isUse)
            {
                copyObstacleList[i].isUse = true;
                copyObstacleList[i].transform.position = new Vector3(0f, 0f, 60f);
                copyObstacleList[i].gameObject.active = true;
                return;
            }
        }
    }

    public void DesactivateThisObstacle(GameObject go)
    {
        Obstacle ob = go.GetComponent<Obstacle>();

        go.active = false;
        go.transform.position = Vector3.zero;
    }

    //A améliorer
    public static void SaveInObstacleList(string obsName)
    {
        GameObject go = Instantiate(Resources.Load("Prefab/Levels/" + obsName, typeof(GameObject)), Object.FindObjectOfType<ObstacleParent>().transform) as GameObject;
        staticObstacleList.Add(go.GetComponent<ObstacleBehavior>());
        /*GameObject go1 = Instantiate(Resources.Load("Prefab/Levels/" + obsName, typeof(GameObject)), Object.FindObjectOfType<ObstacleParent>().transform) as GameObject;
        staticObstacleList.Add(go1.GetComponent<ObstacleBehavior>());
        GameObject go2 = Instantiate(Resources.Load("Prefab/Levels/" + obsName, typeof(GameObject)), Object.FindObjectOfType<ObstacleParent>().transform) as GameObject;
        staticObstacleList.Add(go2.GetComponent<ObstacleBehavior>());*/

        go.SetActive(false);
        /*go1.SetActive(false);
        go2.SetActive(false);*/
    }

    public void SetList()
    {
        staticObstacleList.Clear();

        for(int i = 0; i < obstaclePrepared.childCount; i++)
        {
            staticObstacleList.Add(obstaclePrepared.GetChild(i).gameObject.GetComponent<ObstacleBehavior>());
            copyObstacleList = staticObstacleList;
        }

        isListRefreshed = true;
    }
}
