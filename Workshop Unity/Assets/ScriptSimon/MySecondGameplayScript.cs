using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnnemyProfile
{
    public Color color;
    public float speed;
    public Vector2 spawnPosition;
    public AnimationCurve animC;
}

public class MySecondGameplayScript : MonoBehaviour
{
    public Color myColor;

    [Header("String là là là")]
    public string myString;
    [Multiline]
    public string bigText;

    [Header("Numbers")]
    [Range(0f, 1f)]
    public float myFloat;

    public Vector2 myVector2;

    public string[] myStrings;
    public EnnemyProfile myEnnemyProfile;
}
