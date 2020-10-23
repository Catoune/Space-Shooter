using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public static ShootManager instance;
    public List<ShootBehaviour> shootList = new List<ShootBehaviour>();                //Recup dans l'éditeur
    public Transform shootPrepared;

#if UNITY_EDITOR
    public bool foldoutState;
#endif

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

    public void DesactivateThisShoot(GameObject go)
    {
        ShootBehaviour sb = go.GetComponent<ShootBehaviour>();

        sb.gameObject.active = false;
        sb.transform.position = Vector3.zero;
        sb.isUse = false;
    }

    public void GenerateProjectile(int i)
    {
        if(i > shootList.Count)
        {
            int nbToInstantiate = i - shootList.Count;
            AddProjectile(nbToInstantiate);
        }
        else if(i < shootList.Count)
        {
            int nbToInstantiate = shootList.Count - i;
            RemoveProjectile(Mathf.Abs(nbToInstantiate));
        }
    }

    public int GetNbProjectile()
    {
        return shootList.Count;
    }

    public void AddProjectile(int i)
    {
        for(int j = 0; j < i; j++)
        {
            GameObject go = Instantiate(Resources.Load("Prefab/Projectile", typeof(GameObject)), shootPrepared.transform) as GameObject;
            shootList.Add(go.GetComponent<ShootBehaviour>());
        }
    }

    public void RemoveProjectile(int i)
    {
        Debug.Log(i);
        for (int j = 0; j < i; j++)
        {
            GameObject goToDelete = shootList[0].gameObject;
            shootList.Remove(shootList[0]);
            DestroyImmediate(goToDelete);
        }
    }

    public void ChangeSpeed(float speedVoulu)
    {
        Debug.Log(speedVoulu);
        foreach(ShootBehaviour sb in shootList)
        {
            sb.speed = speedVoulu;
        }
    }
}
