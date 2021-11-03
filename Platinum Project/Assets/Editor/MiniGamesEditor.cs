using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

//[CanEditMultipleObjects]
[CustomEditor(typeof(FortuneWheelSpin))]
public class MiniGamesEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FortuneWheelSpin _source = (FortuneWheelSpin) target;

        EditorGUILayout.LabelField("Editor Window", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        GUILayout.Button("+");
    }

    public void CreateNewGame()
    {

    }
}
