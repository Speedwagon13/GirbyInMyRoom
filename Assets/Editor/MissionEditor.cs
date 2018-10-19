using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Mission))]
public class MissionEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        Mission myTarget = (Mission)target;

        myTarget.missionIcon = (Sprite)EditorGUILayout.ObjectField("Mission Icon", myTarget.missionIcon, typeof(Sprite));
        
        EditorGUILayout.LabelField("Condition Met: ", myTarget.ConditionMet ? "true" : "false");
        EditorGUILayout.LabelField("Items Count: ", (myTarget.ItemsCount).ToString());
    }
}