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
    public int nbOfGames;
    public float timeRotate;
    public float nbCircleRotate;

    private const float CIRCLE = 360.0f;
    private float angleOfOneGame;

    private Transform canvas;
    private float currentTime;

    public AnimationCurve curve;

    [SerializeField] private List<GameObject> gameList = new List<GameObject>();
    

    public bool DevOneGame = true;

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

        int indexGameRandom = Random.Range(0, nbOfGames);
        Debug.Log(indexGameRandom);

        float angleWanted = (nbCircleRotate * CIRCLE) + angleOfOneGame * indexGameRandom - startAngle;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWanted * curve.Evaluate(currentTime / timeRotate);
            transform.localEulerAngles = new Vector3(0, 0, angleCurrent + startAngle - angleOfOneGame);
        }

        if (DevOneGame)
        {
            InstantiateGame(0);
        }
        else
        {
            InstantiateGame(indexGameRandom);
        }
        
    }

    public void InstantiateGame(int index)
    {
        Instantiate(gameList[index], canvas);
        Destroy(this.transform.parent.gameObject);
    }
}
