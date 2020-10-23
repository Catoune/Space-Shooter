using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShootManager))]
public class ShootManagerInspector : Editor
{
    ShootManager currentProfile;

    public int currentNbProjectile;
    public int nbProjectileVoulu = 0;
    public float speedVoulu = 3f;

    private void OnEnable()
    {
        currentProfile = (target as ShootManager);
        currentProfile.shootPrepared = Object.FindObjectOfType<ShootParent>().transform;
    }

    public override void OnInspectorGUI()
    {
        Color oldColor = GUI.color;

        /*if (GUILayout.Button("SET ALL REFERENCES"))
        {
            AutoSetReference();
        }*/

        GUI.enabled = false;
        Transform transformResult = EditorGUILayout.ObjectField("Parent des projectiles : ", currentProfile.shootPrepared, typeof(Transform), true) as Transform;
        GUI.enabled = true;

        currentNbProjectile = currentProfile.GetNbProjectile();
        EditorGUILayout.HelpBox("Il y'a actuellement " + currentNbProjectile + " projectiles dans Shoot Prepared", MessageType.Error);

        nbProjectileVoulu = EditorGUILayout.IntField("Nombre de Projectile à préparer :", nbProjectileVoulu);

        GUI.enabled = false;

        if (nbProjectileVoulu > 0)
        {
            GUI.enabled = true;        
        }

        if (GUILayout.Button("Generate Projectile"))
        {
            currentProfile.GenerateProjectile(nbProjectileVoulu);
        }

        GUI.enabled = true;
        speedVoulu = EditorGUILayout.FloatField("Vitesse des projectiles :", speedVoulu);

        //PS : Save vitesse
        if(speedVoulu != 3f)
        {
            currentProfile.ChangeSpeed(speedVoulu);
        }

        GUI.color = oldColor;
    }

    /*void AutoSetReference()
    {
        Undo.RecordObject(currentProfile, "Just Set Reference");
    }*/
}
