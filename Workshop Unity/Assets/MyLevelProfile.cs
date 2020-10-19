using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Profil.asset", menuName = "Alex/New Level File", order = 7)]
public class MyLevelProfile : ScriptableObject
{
    public float difficulty;
    public Color environmentColor;
    public int[] levelValues;
}
