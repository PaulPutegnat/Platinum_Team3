using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniGame : MonoBehaviour
{
    public List<AnimationClip> spawnWheelAnimations = new List<AnimationClip>();

    public IEnumerator SpawnAnimation()
    {
        Animator fwAnimation = GetComponentInParent<Animator>();
        int RandomIndex = Random.Range(1, spawnWheelAnimations.Count);
        fwAnimation.Play(spawnWheelAnimations[RandomIndex].name);


        yield return new WaitForSeconds(spawnWheelAnimations[RandomIndex].length);
    }

}
