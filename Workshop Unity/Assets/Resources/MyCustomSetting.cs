using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Setting", menuName = "Custom")]
public class MyCustomSetting : ScriptableObject
{
    public float someFloat = 2f;
    public Color someColor = Color.blue;
    public Vector3 someVector = new Vector3(3, 3, 3);
    
}
