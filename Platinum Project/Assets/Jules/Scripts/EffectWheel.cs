using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EffectWheel : MonoBehaviour
{
    [SerializeField] private int nbOfEffects;
    [SerializeField] private float timeRotate;
    [SerializeField] private float nbCircleRotate;

    private const float CIRCLE = 360.0f;
    private float angleOfOneGame;
    private int indexRandom;

    private float currentTime;

    [SerializeField] private AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(RotateWheel());

        angleOfOneGame = CIRCLE / nbOfEffects;
    }

    IEnumerator RotateWheel()
    {
        yield return new WaitForSeconds(.1f);
        GameWheel fwScript = transform.parent.GetComponentInChildren<GameWheel>();
        if (fwScript.index == 1)
        {
            indexRandom = nbOfEffects + 1;
        }
        else
        {
            indexRandom = Random.Range(0, nbOfEffects);
        }

        float startAngle = transform.eulerAngles.z;
        currentTime = 0;

        
        

        float angleWanted = (nbCircleRotate * CIRCLE) + angleOfOneGame * indexRandom - startAngle;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWanted * curve.Evaluate(currentTime / timeRotate);
            transform.localEulerAngles = new Vector3(0, 0, angleCurrent + startAngle - angleOfOneGame);
        }

        if (fwScript.index != 1)
        {
            TrapsEffects.instanceTrapsEffects.trapNum = indexRandom;
        }
    }
}
