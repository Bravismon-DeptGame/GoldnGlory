using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Datas))]
public class DatasEditor : Editor {

    bool toggle;

    private void OnEnable()
    {
        toggle = !((Datas)target).doubleChoice;
    }

    public override void OnInspectorGUI()
    {
        Datas data = (Datas) target;
        base.OnInspectorGUI();
        
        serializedObject.Update ();

        data.name = data.codeDialog;
        data.doubleChoice = EditorGUILayout.Toggle("Double Choice",data.doubleChoice);
        if (data.doubleChoice)
        {
            if (toggle != data.doubleChoice)
            {
                data.pointer = new Datas[2];
            }
            toggle = data.doubleChoice;
            
            data.pointer[0] = (Datas) EditorGUILayout.ObjectField("Pointer Kiri",data.pointer[0],typeof(Datas),false);
            data.pointer[1] = (Datas) EditorGUILayout.ObjectField("Pointer Kanan", data.pointer[1], typeof(Datas), false);
            
            EditorGUILayout.LabelField("Reject");
            data.reject = EditorGUILayout.TextArea(data.reject, GUILayout.MaxHeight(50));
            EditorGUILayout.LabelField("Accept");
            data.accept = EditorGUILayout.TextArea( data.accept , GUILayout.MaxHeight(50));
        } else
        {
            if (toggle != data.doubleChoice)
            {
                data.pointer = new Datas[1];
            }
            toggle = data.doubleChoice;
            data.pointer[0] = (Datas)EditorGUILayout.ObjectField("Pointer",data.pointer[0], typeof(Datas), false);
            data.reject = null;
            data.accept = null;
        }
                     
        serializedObject.ApplyModifiedProperties ();
    }
}
