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

    private Transform gameContainer;
    private float currentTime;

    [SerializeField] private AnimationCurve curve;

    [SerializeField] private List<GameObject> gameList = new List<GameObject>();


    [SerializeField] private bool DevOneGame = true;

    private void Start()
    {
        StartCoroutine(SpawnAnimation()); //executer en parallèle du reste de code

        StartCoroutine(RotateWheel()); 

        angleOfOneGame = CIRCLE / nbOfGames;
        gameContainer = GameObject.FindGameObjectWithTag("GameContainer").transform;
    }

    IEnumerator RotateWheel()
    {
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;

        int indexRandom = Random.Range(0, nbOfGames);
        Debug.Log(gameList[indexRandom]);
        index = indexRandom;

        float angleWanted = (nbCircleRotate * CIRCLE) + angleOfOneGame * indexRandom;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWanted * curve.Evaluate(currentTime / timeRotate);
            transform.localEulerAngles = new Vector3(0, 0, angleCurrent + startAngle - (angleOfOneGame * indexRandom));
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
        Instantiate(gameList[index], gameContainer);
        Destroy(this.transform.parent.gameObject);
    }
}
