using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public static ShootManager instance;
    public ShootBehaviour[] shootList;                //Recup dans l'éditeur

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
    }

    public void InstantiateShoot()
    {
        foreach(ShootBehaviour shoot in shootList)
        {
            if(!shoot.isUse)
            {
                shoot.isUse = true;
                shoot.transform.position = PlayerManager.instance.canon.transform.position;
                shoot.gameObject.active = true;
                return;
            }
        }
    }
}
