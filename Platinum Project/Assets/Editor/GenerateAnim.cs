using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.UI;

namespace Assets.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MiniGame), true)]
    public class GenerateAnim : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MiniGame source = (MiniGame)target;

            EditorGUILayout.LabelField("Editor Window", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            if (GUILayout.Button("Generate Animations"))
            {
                GenerateAnimatorState(source.spawnWheelAnimations, source.gameObject);
            }
        }


        public void GenerateAnimatorState(List<AnimationClip> animationList, GameObject gameObjectRef)
        {
            int animCount = animationList.Count;
            Animator myAnimator = gameObjectRef.GetComponentInParent<Animator>();
            //AnimatorController animController = (AnimatorController)AssetDatabase.LoadAssetAtPath(AssetDatabase.GetAssetPath(MyAnimator.runtimeAnimatorController), typeof(AnimatorController));
            AnimatorController animController = myAnimator.runtimeAnimatorController as AnimatorController;

            
            for (int i = animController.layers[0].stateMachine.states.Length - 1; i >= 0; i--)
            {
                AnimatorState animatorState = animController.layers[0].stateMachine.states[i].state;
                animController.layers[0].stateMachine.RemoveState(animatorState);
            }

            for (int i = 0; i < animCount; i++)
            {
                animController.AddMotion(animationList[i]);
            }
        }
    }
}

