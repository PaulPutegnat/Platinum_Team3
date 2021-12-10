using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EffectWheel : MonoBehaviour
{
    [SerializeField] private int nbOfEffects;
    private int indexRandom;

    private void Start()
    {
        StartCoroutine(RotateWheel());
    }

    IEnumerator RotateWheel()
    {
        yield return new WaitForSeconds(.3f);
        GameWheel fwScript = transform.parent.GetComponentInChildren<GameWheel>();
        if (fwScript.index == 1)
        {
            indexRandom = nbOfEffects + 1;
        }
        else
        {
            indexRandom = Random.Range(0, nbOfEffects);
        }

        if (fwScript.index != 1)
        {
            TrapsEffects.instanceTrapsEffects.trapNum = indexRandom;
        }
    }
}
