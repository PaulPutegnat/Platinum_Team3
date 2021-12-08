using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWheel : MiniGame
{
    [SerializeField] private int nbOfGames;
    [SerializeField] private float timeRotate;
    [SerializeField] private float nbCircleRotate;

    private const float CIRCLE = 360.0f;
    private float angleOfOneGame;
    [HideInInspector]public int index;

    private Transform trapManager;
    private float currentTime;

    [SerializeField] private AnimationCurve curve;

    [SerializeField] private List<GameObject> gameList = new List<GameObject>();


    [SerializeField] private bool DevOneGame = true;

    private void Start()
    {
        StartCoroutine(SpawnAnimation()); //executer en parallèle du reste de code

        StartCoroutine(RotateWheel()); 

        angleOfOneGame = CIRCLE / nbOfGames;
        trapManager = GameObject.FindGameObjectWithTag("TrapManager").transform;
    }

    IEnumerator RotateWheel()
    {
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;

        int indexRandom = Random.Range(0, nbOfGames);
        Debug.Log(indexRandom);
        index = indexRandom;

        float angleWanted = (nbCircleRotate * CIRCLE) + angleOfOneGame * indexRandom - startAngle;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWanted * curve.Evaluate(currentTime / timeRotate);
            transform.localEulerAngles = new Vector3(0, 0, angleCurrent + startAngle - angleOfOneGame);
        }

        yield return DespawnAnimation();

        if (DevOneGame)
        {
            InstantiateGame(0);
        }
        else
        {
            InstantiateGame(indexRandom);
        }
    }

    public void InstantiateGame(int index)
    {
        Instantiate(gameList[index], trapManager);
        Destroy(this.transform.parent.gameObject);
    }
}
