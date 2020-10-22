using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool isUse = true;
    public float speed = 4f;

    private void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Projectile"))
        {
            ShootManager.instance.DesactivateThisShoot(collision.gameObject);
            gameObject.active = false;
            isUse = false;
        }
    }
}
