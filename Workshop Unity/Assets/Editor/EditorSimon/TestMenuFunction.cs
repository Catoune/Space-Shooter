using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestMenuFunction
{
    [MenuItem("Tools/Alex/Set References %w")]
   public static void HelloWorld()
   {
        Debug.Log("Starting to find references ....");

        MyHeavyGameplayScript manager = Object.FindObjectOfType<MyHeavyGameplayScript>();

        Undo.RecordObject(manager, "Just Set Reference");

        manager.audioListener = Object.FindObjectOfType<AudioListener>();
        manager.myCamera = Object.FindObjectOfType<Camera>();
        manager.selfTransform = manager.transform;
        manager.camTransform = manager.myCamera.transform;
   }
}
