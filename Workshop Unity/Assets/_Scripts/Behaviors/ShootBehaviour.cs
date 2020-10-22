using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    public float speed = 3f;
    public bool isUse = false;
    void Update()
    {
        transform.Translate(-Vector3.down * speed * Time.deltaTime);
    }
}
