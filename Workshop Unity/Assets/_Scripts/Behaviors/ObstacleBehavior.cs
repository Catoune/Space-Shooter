using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public bool isUse = true;
    public float speed = 4f;

    private void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}
