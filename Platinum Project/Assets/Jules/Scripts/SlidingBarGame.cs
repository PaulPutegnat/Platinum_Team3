using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingBarGame : MonoBehaviour
{
    // Inputs Action
    private MiniGameAction inputActions;
    private bool p1ButtonPressed = false;
    private bool p2ButtonPressed = false;

    [Header("GameObjects")]
    public GameObject handleP1;
    public GameObject handleP2;
    public GameObject slidingBox;
    public GameObject intervalP1;
    public GameObject intervalP2;

    [Header("Settings")]
    public bool isDoubleInterval = false;
    public float speed;
    public float minIntervalSize, maxIntervalSize;


    private float minIntervalPos = -550f, maxIntervalPos = 550f;
    private Vector2 intervalP1Size;
    private Vector2 intervalP2Size;
    private Vector3 startPosP1;
    private Vector3 startPosP2;
    private Vector3 lastPosP1;
    private Vector3 lastPosP2;
    private bool isP1Playing = false;
    private bool isP2Playing = false;
    private float maxBoundBox;


    private void Awake()
    {
        inputActions = new MiniGameAction();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    void Start()
    {
        if (isDoubleInterval)
        {
            intervalP2.SetActive(true);
        }
        else
        {
            intervalP2.SetActive(false);
        }

        intervalP1.transform.localPosition = new Vector3(Random.Range(minIntervalPos, maxIntervalPos), intervalP1.transform.localPosition.y);
        intervalP2.transform.localPosition = new Vector3(Random.Range(minIntervalPos, maxIntervalPos), intervalP2.transform.localPosition.y);
        intervalP1.GetComponent<RectTransform>().sizeDelta = new Vector2(Random.Range(minIntervalSize, (maxIntervalSize + 1)), 100f);
        intervalP2.GetComponent<RectTransform>().sizeDelta = new Vector2(Random.Range(minIntervalSize, (maxIntervalSize + 1)), 100f);

        intervalP1Size = intervalP1.GetComponent<RectTransform>().sizeDelta;
        intervalP2Size = intervalP2.GetComponent<RectTransform>().sizeDelta;

        startPosP1 = handleP1.transform.localPosition;
        startPosP2 = handleP2.transform.localPosition;
        maxBoundBox = slidingBox.GetComponent<RectTransform>().sizeDelta.x - 10f;

        StartSlidingBarGame(true);
    }
    void Update()
    {
        p1ButtonPressed = inputActions.MiniGame.SlidingBarP1.triggered;
        p2ButtonPressed = inputActions.MiniGame.SlidingBarP2.triggered;

        if (p1ButtonPressed)
        {
            isP1Playing = false;
        }

        if (p2ButtonPressed)
        {
            isP2Playing = false;
        }

        if (isP1Playing)
        {
            handleP1.transform.localPosition = new Vector3(startPosP1.x + Mathf.PingPong(Time.time * speed, maxBoundBox), handleP1.transform.localPosition.y, 0);
            lastPosP1 = handleP1.transform.localPosition;
        }
        else
        {
            StopP1SlidingBarGame();
        }

        if (isP2Playing)
        {
            handleP2.transform.localPosition = new Vector3(startPosP2.x - Mathf.PingPong(Time.time * speed, maxBoundBox), handleP2.transform.localPosition.y, 0);
            lastPosP2 = handleP2.transform.localPosition;
        }
        else
        {
            StopP2SlidingBarGame();
        }
    }

    public void StartSlidingBarGame(bool state)
    {
        isP1Playing = state;
        isP2Playing = state;
    }

    public void StopP1SlidingBarGame()
    {
        Vector3 handlePosP1 = handleP1.transform.localPosition;
        handlePosP1 = lastPosP1;

            if (handlePosP1.x < (intervalP1.transform.localPosition + ((Vector3)intervalP1Size / 2)).x && handlePosP1.x > (intervalP1.transform.localPosition - ((Vector3)intervalP1Size / 2)).x)
            {
                Debug.Log("P1 a gagn�!!!");
            }
        
    }
    public void StopP2SlidingBarGame()
    {
        Vector3 handlePosP2 = handleP2.transform.localPosition;
        handlePosP2 = lastPosP2;

        if (!isDoubleInterval)
        {
            if (handlePosP2.x < (intervalP1.transform.localPosition + ((Vector3)intervalP1Size / 2)).x && handlePosP2.x > (intervalP1.transform.localPosition - ((Vector3)intervalP1Size / 2)).x)
            {
                Debug.Log("P2 a gagn�!!!");
            }
        }
        else
        {
            if (handlePosP2.x < (intervalP2.transform.localPosition + ((Vector3)intervalP2Size / 2)).x && handlePosP2.x > (intervalP2.transform.localPosition - ((Vector3)intervalP2Size / 2)).x)
            {
                Debug.Log("P2 a gagn�!!!");
            }
        }

    }
}
