using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeavyGameplayScript : MonoBehaviour
{
    public Camera myCamera;
    public Transform selfTransform;
    public Transform camTransform;
    public AudioListener audioListener;

    [System.NonSerialized]
    public float mySpeed;

    [SerializeField]
    private float test;

    public Color color;
    public Vector3 vector3;
    public string st;
    public AnimationCurve myCurve;

    public WrapMode enumExemple;

#if UNITY_EDITOR
    public bool foldoutState;
#endif

    private void Start()
    {
        mySpeed = 3;
        test = 7;
    }

    private void Update()
    {
        
    }
}
