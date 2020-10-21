using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Transform canon;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
    }
}
