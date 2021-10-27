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
        SerializedProperty changeFovProperty = property.FindPropertyRelative("ChangeFov");
        SerializedProperty changePositionProperty = property.FindPropertyRelative("ChangePosition");
        SerializedProperty changeRotationProperty = property.FindPropertyRelative("ChangeRotation");

        //Change element size based on default unity element size
        position.height = EditorGUIUtility.singleLineHeight;

        //Display into editor using position 
        EditorGUI.PropertyField(position, property.FindPropertyRelative("Target"));

        //Move rectangle based on previous element height;
        position.y += EditorGUIUtility.singleLineHeight;
        EditorGUI.PropertyField(position, changeFovProperty);

        if (changeFovProperty.boolValue)
        {
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property.FindPropertyRelative("Fov"));
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property.FindPropertyRelative("TimeToFov"));
        }

        position.y += EditorGUIUtility.singleLineHeight;
        EditorGUI.PropertyField(position, changePositionProperty);

        if (changePositionProperty.boolValue)
        {
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property.FindPropertyRelative("TimeToNextTarget"));
        }


        position.y += EditorGUIUtility.singleLineHeight;
        EditorGUI.PropertyField(position, changeRotationProperty);

        if (changeRotationProperty.boolValue)
        {
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property.FindPropertyRelative("TimeToRotate"));
        }
    }

    //Size of an element
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight * 4;

        SerializedProperty changeFovProperty = property.FindPropertyRelative("ChangeFov");
        SerializedProperty changePositionProperty = property.FindPropertyRelative("ChangePosition");
        SerializedProperty changeRotationProperty = property.FindPropertyRelative("ChangeRotation");

        if (changeFovProperty.boolValue)
        {
            height += EditorGUIUtility.singleLineHeight * 2;
        }

        if (changePositionProperty.boolValue)
        {
            height += EditorGUIUtility.singleLineHeight;
        }

        if (changeRotationProperty.boolValue)
        {
            height += EditorGUIUtility.singleLineHeight;
        }

        return height;
    }
} 
