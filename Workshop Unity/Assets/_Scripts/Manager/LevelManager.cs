using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform EditorCreationTab;

    public List<GameObject> listLevel;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
    }
}
