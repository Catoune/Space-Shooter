using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SomeCommonComponent : MonoBehaviour
{
    //Iterator <-- GetIterator arrive là et Next va prendre les enfants
    public float myFloat;
    public bool myBool;
    public Bounds myBounds;
    public Rect myRect;
    //myRect.x
    //myRect.y
    //myRect.z ...
    public AnimationCurve myCurve;
    public Color myColor;
    public string myString;
    public Vector3 myVector;
    public Object myObject;             //PPtr<$Object>
    public AudioSource myAudioSrc;      //PPtr<$AudioSource>
    public UnityEvent ue;

    public Color[] myArray;
}
