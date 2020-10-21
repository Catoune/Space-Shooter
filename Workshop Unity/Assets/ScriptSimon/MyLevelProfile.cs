using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Profil.asset", menuName = "Alex/New Level File", order = 7)]
public class MyLevelProfile : ScriptableObject
{
    public float difficulty;
    public Color environmentColor;
    public AnimationCurve someCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    public int[] levelValues;
}
