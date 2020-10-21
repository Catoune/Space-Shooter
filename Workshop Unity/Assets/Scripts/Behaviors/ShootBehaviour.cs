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
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z * speed * Time.deltaTime);
        transform.Translate(-Vector3.down * speed * Time.deltaTime);
    }
}
