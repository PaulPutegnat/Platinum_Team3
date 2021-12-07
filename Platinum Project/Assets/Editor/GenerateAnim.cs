using System.Collections.Generic;
using System.Linq;
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
                GenerateAnimatorState(source.SpawnAnim, source.DespawnAnim, source.gameObject);
            }
        }


        public void GenerateAnimatorState(List<AnimationClip> spawnAnimList, List<AnimationClip> despawnAnimList, GameObject gameObjectRef)
        {
            int animCount = spawnAnimList.Count + despawnAnimList.Count;
            Animator myAnimator = gameObjectRef.GetComponentInParent<Animator>();
            //AnimatorController animController = (AnimatorController)AssetDatabase.LoadAssetAtPath(AssetDatabase.GetAssetPath(MyAnimator.runtimeAnimatorController), typeof(AnimatorController));
            AnimatorController animController = myAnimator.runtimeAnimatorController as AnimatorController;
            List<AnimationClip> totalAnimClipList = new List<AnimationClip>();
            for (int i = 0; i < animCount; i++)
            {
                totalAnimClipList.Add(spawnAnimList[i]);
            }
            totalAnimClipList.AddRange(despawnAnimList);

            for (int i = animController.layers[0].stateMachine.states.Length - 1; i >= 0; i--)
            {
                AnimatorState animatorState = animController.layers[0].stateMachine.states[i].state;
                animController.layers[0].stateMachine.RemoveState(animatorState);
            }

            for (int i = 0; i < animCount; i++)
            {
                animController.AddMotion(totalAnimClipList[i]);
            }
        }
    }
}

