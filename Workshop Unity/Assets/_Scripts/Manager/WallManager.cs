using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public static WallManager instance;

    public Transform wallPrepared;
    public MoveForward[] wallList;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
    }

    public void InstantiateWall(GameObject lastWall)
    {
        foreach (MoveForward wall in wallList)
        {
            if (!wall.isUse)
            {
                wall.isUse = true;
                wall.isLast = true;
                wall.transform.position = new Vector3(0f, 0f, lastWall.transform.position.z + 10f);
                wall.gameObject.active = true;
                return;
            }
        }
    }
}
