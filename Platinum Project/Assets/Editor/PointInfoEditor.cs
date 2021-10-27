using System.Collections;
using System.Collections.Generic;
using Cinemachine.Editor;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PointInfo))]

//Change serializable class visual
public class PointInfoEditor : PropertyDrawer
{
    //Display PointInfo in Editor
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Get variable from Pointinfo
        SerializedProperty PropertyIsChangingFov = property.FindPropertyRelative("IsChangingFov");

        //Change element size based on default unity element size
        position.height = EditorGUIUtility.singleLineHeight;

        //Display into editor using position 
        EditorGUI.PropertyField(position, property.FindPropertyRelative("Target"));

        //Move rectangle based on previous element height;
        position.y += EditorGUIUtility.singleLineHeight;
        EditorGUI.PropertyField(position, PropertyIsChangingFov);

        if (PropertyIsChangingFov.boolValue)
        {
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property.FindPropertyRelative("Fov"));
        }
    }

    //Size of an element
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight * 2;

        SerializedProperty PropertyIsChangingFov = property.FindPropertyRelative("IsChangingFov");

        if (PropertyIsChangingFov.boolValue)
        {
            height += EditorGUIUtility.singleLineHeight;
        }
        return height;
    }
} 
