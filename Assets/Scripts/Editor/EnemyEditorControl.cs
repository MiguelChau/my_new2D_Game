using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyNew))]
public class EnemyEditorControl : Editor
{
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();

        EnemyNew mytarget = (EnemyNew)target;

        mytarget.enemyPrefab = (GameObject)EditorGUILayout.ObjectField(mytarget.enemyPrefab, typeof(GameObject), true);

        mytarget.attack = EditorGUILayout.IntField("Force", mytarget.attack);
        mytarget.health = EditorGUILayout.IntField("Stamina", mytarget.health);

        EditorGUILayout.LabelField("Total Strength", mytarget.TotalStrength.ToString());

        EditorGUILayout.HelpBox("Calculate the total Strength", MessageType.Info);

        if (mytarget.TotalStrength > 500)
        {
            EditorGUILayout.HelpBox("Not allowed above 500", MessageType.Error);
        }

        GUI.color = Color.green;

        if (GUILayout.Button("Create Enemy"))
        {
            mytarget.CreateEnemy();
        }
        Debug.Log("Update GUI");

    }
}
