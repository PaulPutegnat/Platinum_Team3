using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(SlidingBarGame))]
public class SlidingBarGameEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SlidingBarGame game = (SlidingBarGame) target;

        GUILayout.Space(20f);
        EditorGUILayout.LabelField("Toggle Double Interval");
        game.isDoubleInterval = GUILayout.Toggle(game.isDoubleInterval, "Double Interval");

        EditorGUI.BeginChangeCheck();

        Color handleP1Color = game.handleP1.GetComponent<Image>().color;
        Color handleP2Color = game.handleP2.GetComponent<Image>().color;

        GUILayout.Space(20f);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("P1 : ", GUILayout.Width(25));
        Color newHandleP1Color = EditorGUILayout.ColorField(handleP1Color);
        EditorGUILayout.LabelField("P2 : ", GUILayout.Width(25));
        Color newHandleP2Color = EditorGUILayout.ColorField(handleP2Color);
        EditorGUILayout.EndHorizontal();

        if (EditorGUI.EndChangeCheck())
        {
            game.handleP1.GetComponent<Image>().color = newHandleP1Color;
            game.handleP2.GetComponent<Image>().color = newHandleP2Color;
            EditorApplication.QueuePlayerLoopUpdate();
        }

        

        if (!game.isDoubleInterval)
        {
            Debug.Log("Only one interval!!");
            game.intervalP2.SetActive(false);
        }
        else
        {
            Debug.Log("Double interval!!");
            game.intervalP2.SetActive(true);
        }
    }
}
