using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Scenes))]
public class ScenesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Scenes scene = (Scenes) target;
        base.OnInspectorGUI();
        
        serializedObject.Update ();
        if (scene.head) scene.head.scene = scene;
        serializedObject.ApplyModifiedProperties ();
    }
}