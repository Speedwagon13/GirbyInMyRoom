using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Condition))]
public class ConditionEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        Condition myTarget = (Condition)target;
        
        EditorGUILayout.LabelField("Condition Met: ", myTarget.ConditionMet ? "true" : "false");
    }
}