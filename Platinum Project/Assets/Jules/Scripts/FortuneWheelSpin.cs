using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditorInternal;
using AnimatorController = UnityEditor.Animations.AnimatorController;

public class FortuneWheelSpin : MiniGame
{
    [SerializeField] private int nbOfGames;
    [SerializeField] private float timeRotate;
    [SerializeField] private float nbCircleRotate;

    private const float CIRCLE = 360.0f;
    private float angleOfOneGame;

    private Transform canvas;
    private float currentTime;

    [SerializeField] private AnimationCurve curve;

    [SerializeField] private List<GameObject> gameList = new List<GameObject>();


    [SerializeField] private bool DevOneGame = true;
    [SerializeField] private bool EffectWheel = false;

    private IEnumerator Start()
    {
        yield return StartCoroutine(SpawnAnimation()); //executer en parallèle du reste de code

        StartCoroutine(RotateWheel()); 

        angleOfOneGame = CIRCLE / nbOfGames;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        
        
    }

    IEnumerator RotateWheel()
    {
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;

        int indexRandom = Random.Range(0, nbOfGames);
        Debug.Log(indexRandom);

        float angleWanted = (nbCircleRotate * CIRCLE) + angleOfOneGame * indexRandom - startAngle;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWanted * curve.Evaluate(currentTime / timeRotate);
            transform.localEulerAngles = new Vector3(0, 0, angleCurrent + startAngle - angleOfOneGame);
        }

        if (!EffectWheel)
        {
            if (DevOneGame)
            {
                InstantiateGame(0);
            }
            else
            {
                InstantiateGame(indexRandom);
            }
        }
        else
        {
            // indexRandom
        }
    }

    public void InstantiateGame(int index)
    {
        Instantiate(gameList[index], canvas);
        Destroy(this.transform.parent.gameObject);
    }
}
