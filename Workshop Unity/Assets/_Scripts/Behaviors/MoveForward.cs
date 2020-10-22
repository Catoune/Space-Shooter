using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 2f;
    public bool isUse = false;
    public bool isLast = false;
    public float limiteSpawnZ = 40f;

    void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);

        if(transform.position.z <= -15)
        {
            gameObject.active = false;
            transform.position = Vector3.zero;
            isUse = false;
        }

        if(isLast && transform.position.z <= limiteSpawnZ)
        {
            isLast = false;
            WallManager.instance.InstantiateWall(gameObject);
        }
    }
}
