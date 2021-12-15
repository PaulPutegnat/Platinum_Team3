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
        yield return new WaitForSeconds(1.5f);
        GameWheel fwScript = transform.GetChild(0).GetComponent<GameWheel>();
        if (fwScript.index == 2)
        {
            indexRandom = nbOfEffects;
        }
        else
        {
            indexRandom = (int)Random.Range(1, nbOfEffects);
            //Debug.Log("index trap effect : " + indexRandom);
            TrapsEffects.instanceTrapsEffects.trapNum = indexRandom;
        }
    }
}
