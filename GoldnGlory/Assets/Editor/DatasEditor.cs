using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Datas))]
public class DatasEditor : Editor {

    public override void OnInspectorGUI()
    {
        Datas data = (Datas) target;
        base.OnInspectorGUI();
        
        serializedObject.Update ();

        data.name = data.codeDialog;
        data.doubleChoice = EditorGUILayout.Toggle("Double Choice",data.doubleChoice);

        if (data.pointer == null) data.pointer = new Datas[data.doubleChoice ? 2 : 1];
        
        if (data.doubleChoice)
        {
            if (data.doubleChoice && data.pointer.Length != 2)
            {
                data.pointer = new Datas[2];
            }
            
            data.pointer[0] = (Datas) EditorGUILayout.ObjectField("Pointer Kiri",data.pointer[0],typeof(Datas),false);
            data.pointer[1] = (Datas) EditorGUILayout.ObjectField("Pointer Kanan", data.pointer[1], typeof(Datas), false);

            if (data.pointer[0]) data.pointer[0].parent = data;
            if (data.pointer[1]) data.pointer[1].parent = data;
            
            EditorGUILayout.LabelField("Reject");
            data.reject = EditorGUILayout.TextArea(data.reject, GUILayout.MaxHeight(50));
            EditorGUILayout.LabelField("Accept");
            data.accept = EditorGUILayout.TextArea( data.accept , GUILayout.MaxHeight(50));
        } else
        {
            if (data.pointer.Length != 1)
            {
                data.pointer = new Datas[1];
            }

            data.pointer[0] = (Datas)EditorGUILayout.ObjectField("Pointer",data.pointer[0], typeof(Datas), false);
            if (data.pointer[0]) data.pointer[0].parent = data;
            data.reject = null;
            data.accept = null;
        }

        if (data.scene)
        {
            EditorGUILayout.LabelField("Head of Scene "+data.scene);
        }

        if (data.parent)
        {
            EditorGUILayout.LabelField("Parent of this data is "+data.parent);
        }
                   
        serializedObject.ApplyModifiedProperties ();
    }
}
