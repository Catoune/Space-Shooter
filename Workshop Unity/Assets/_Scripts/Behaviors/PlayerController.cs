using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x;
    float y;

    Vector3 axisX;
    Vector3 axisY;

    float speed = 6f;
    bool justPressed = false;

    public float delay = 0.1f;

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        axisX = (new Vector3(x, 0f, 0f)) * speed * Time.deltaTime;
        axisY = (new Vector3(0f, y, 0f)) * speed * Time.deltaTime;

        if ((y > 0 && transform.position.y <= 9f) || (y < 0 && transform.position.y >= 1f))
        {
            transform.position += axisY;
        }
        if((x > 0 && transform.position.x <= 9f) || (x < 0 && transform.position.x >= 1f))
        {
            transform.position += axisX;
        }

        if(Input.GetButton("Jump") && !justPressed)
        {
            justPressed = true;
            ShootManager.instance.InstantiateShoot();
            StartCoroutine("DelayShoot");
        }
    }

    IEnumerator DelayShoot()
    {
        yield return new WaitForSeconds(delay);
        justPressed = false;
    }
}
