using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool isUse = true;

    private void Update()
    {
        if(transform.position.z <= -1f)
        {
            ObstacleManager.instance.DesactivateThisObstacle(gameObject);
        }
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
