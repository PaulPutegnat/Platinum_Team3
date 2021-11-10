using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FortuneWheelSpin : MonoBehaviour
{
    private PlayerControls inputActions;

    public int nbOfGames;
    public float timeRotate;
    public float nbCircleRotate;

    private const float CIRCLE = 360.0f;
    private float angleOfOneGame;

    private Transform canvas;
    private float currentTime;
    private bool isAlreadyRotate = false;

    public AnimationCurve curve;

    public List<GameObject> gameList = new List<GameObject>();

    private void Awake()
    {
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        angleOfOneGame = CIRCLE / nbOfGames;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        RotateNow();
    }

    private void Update()
    {
        /*bool isButtonPressed = inputActions.Trapper.FortuneWheel.triggered;
        if (isButtonPressed && !isAlreadyRotate)
        {
            RotateNow();
            isAlreadyRotate = true;
        }*/
    }

    IEnumerator RotateWheel()
    {

        float startAngle = transform.eulerAngles.z;
        currentTime = 0;

        int indexGameRandom = Random.Range(1, nbOfGames);
        Debug.Log(indexGameRandom);

        float angleWanted = (nbCircleRotate * CIRCLE) + angleOfOneGame * indexGameRandom - startAngle;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWanted * curve.Evaluate(currentTime / timeRotate);
            this.transform.eulerAngles = new Vector3(0, 0, angleCurrent + startAngle - angleOfOneGame);
        }

        switch (indexGameRandom)
        {
            case 0:
                InstantiateGame(indexGameRandom);
                break;

            case 1:
                InstantiateGame(indexGameRandom);
                break;

            case 2:
                InstantiateGame(indexGameRandom);
                break;

            case 3:
                InstantiateGame(indexGameRandom);
                break;

            case 4:
                InstantiateGame(indexGameRandom);
                break;

            case 5:
                InstantiateGame(indexGameRandom);
                break;

            case 6:
                InstantiateGame(indexGameRandom);
                break;

            case 7:
                InstantiateGame(indexGameRandom);
                break;

        }
    }

    public void InstantiateGame(int index)
    {
        Instantiate(gameList[index], canvas);
        Destroy(this.transform.parent.gameObject);
    }

    [ContextMenu("Rotate")]
    void RotateNow()
    {
        StartCoroutine(RotateWheel());
    }
}
