/*using UnityEngine;
using UnityEditor;
 
[CanEditMultipleObjects]
[CustomPropertyDrawer(typeof(Interaction))]
public class InteractionInspector : PropertyDrawer
{
   // Cached scriptable object editor
    private Editor editor = null;
 
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("Interaction"));
       
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        SerializedProperty cp = property.FindPropertyRelative("condition");
    

        //cp.Get

        Debug.Log("interaction: " + EditorGUI.GetPropertyHeight(cp, label));

        Rect condLabelRect = new Rect(position.x, position.y+EditorGUIUtility.singleLineHeight, position.width/2, EditorGUIUtility.singleLineHeight);
        Rect conditionRect = new Rect(position.x+position.width/2, position.y+(EditorGUIUtility.singleLineHeight), position.width/2, EditorGUIUtility.singleLineHeight);
        
        Rect actionLabelRect = new Rect(position.x, position.y+EditorGUI.GetPropertyHeight(cp, label)+(EditorGUIUtility.singleLineHeight), position.width, EditorGUIUtility.singleLineHeight);
        Rect actionRect = new Rect(position.x, position.y+EditorGUI.GetPropertyHeight(cp, label)+(EditorGUIUtility.singleLineHeight), position.width/2, EditorGUIUtility.singleLineHeight);

    
        
        //EditorGUI.LabelField(condLabelRect, "Condition");
        //EditorGUI.PropertyField(conditionRect, property.FindPropertyRelative("condition"), GUIContent.none);

         EditorGUI.LabelField(actionLabelRect, "Action");
        EditorGUI.PropertyField(actionRect, property.FindPropertyRelative("action"), GUIContent.none);
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
        
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        SerializedProperty cp = property.FindPropertyRelative("condition");

        return base.GetPropertyHeight(property, label) + 2*EditorGUIUtility.singleLineHeight; //+ EditorGUI.GetPropertyHeight(cp, label);
    }
}*/