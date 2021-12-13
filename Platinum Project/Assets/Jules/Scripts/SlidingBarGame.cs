using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlidingBarGame : MiniGame
{
    public enum IS_DOUBLE_INTERVAL
    {
        YES,
        NO
    }

    // Inputs Action
    private bool p1ButtonPressed = false;
    private bool p2ButtonPressed = false;

    [Header("GameObjects")]
    public GameObject handleP1;
    public GameObject handleP2;
    public GameObject intervalP1;
    public GameObject intervalP2;

    [Header("Settings")]
    private bool isDoubleInterval = false;
    [SerializeField] private IS_DOUBLE_INTERVAL IsDoubleIntervalEnum = IS_DOUBLE_INTERVAL.NO;

    [Range(0, 1)]
    public float speed;
    public float minIntervalSize, maxIntervalSize;


    private float minIntervalPos = -550f, maxIntervalPos = 550f;
    private Vector2 intervalP1Size;
    private Vector2 intervalP2Size;
    private Vector3 lastPosP1;
    private Vector3 lastPosP2;
    private bool isP1Playing = false;
    private bool isP2Playing = false;

    private float posPercentP1;
    private float posPercentP2;

    private bool isP1Win = false;
    private bool isP2Win = false;

    private bool isTwoPlayer = false;

    

    private void Awake()
    {
        switch (IsDoubleIntervalEnum)
        {
            case IS_DOUBLE_INTERVAL.NO:
                isDoubleInterval = false;
                intervalP2.SetActive(false);
                break;

            case IS_DOUBLE_INTERVAL.YES:
                isDoubleInterval = true;
                intervalP2.SetActive(true);
                break;
        }
    }

    IEnumerator Start()
    {
        intervalP1.transform.localPosition = new Vector3(Random.Range(minIntervalPos, maxIntervalPos), intervalP1.transform.localPosition.y);
        intervalP1.GetComponent<RectTransform>().sizeDelta = new Vector2(Random.Range(minIntervalSize, (maxIntervalSize + 1)), 100f);
        intervalP1Size = intervalP1.GetComponent<RectTransform>().sizeDelta;
        posPercentP1 = Random.Range(-1, 1.1f);
        handleP1.transform.localPosition = new Vector3(posPercentP1 * 600, 0f, 0f);

        if (PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER2] != null)
        {
            intervalP2.transform.localPosition = new Vector3(Random.Range(minIntervalPos, maxIntervalPos), intervalP2.transform.localPosition.y);
            intervalP2.GetComponent<RectTransform>().sizeDelta = new Vector2(Random.Range(minIntervalSize, (maxIntervalSize + 1)), 100f);
            posPercentP2 = Random.Range(-1, 1.1f);
            handleP2.transform.localPosition = new Vector3(posPercentP2 * 600, 0f, 0f);
            intervalP2Size = intervalP2.GetComponent<RectTransform>().sizeDelta;
        }

        yield return StartCoroutine(SpawnAnimation());

        if (PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER2] != null)
        {
            handleP2.SetActive(true);
            isTwoPlayer = true;
        }
        else
        {
            handleP2.SetActive(false);
            isTwoPlayer = false;
        }

        StartSlidingBarGame(true);
    }

    void Update()
    {

        p1ButtonPressed = InputManager.inputManager.SlidingStopP1();
        if (isTwoPlayer)
        {
            p2ButtonPressed = InputManager.inputManager.SlidingStopP2();
        }
  
        
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
            handleP1.transform.localPosition = Vector3.Lerp(new Vector3(-590f, 0, 0), new Vector3(590f, 0, 0), posPercentP1);
            posPercentP1 = Mathf.PingPong(Time.time * speed, 1f);
            lastPosP1 = handleP1.transform.localPosition;
        }
        else
        {
            StopP1SlidingBarGame();
        }

        if (isP2Playing)
        {
            handleP2.transform.localPosition = Vector3.Lerp(new Vector3(590f, 0, 0), new Vector3(-590f, 0, 0), posPercentP2);
            posPercentP2 = Mathf.PingPong(Time.time * speed, 1f);
            lastPosP2 = handleP2.transform.localPosition;
        }
        else
        {
            StopP2SlidingBarGame();
        }

        if (isTwoPlayer)
        {
            if (!isP1Playing && !isP2Playing)
            {
                if (isP1Win && isP2Win)
                {
                    // Game finish Win
                    //Debug.Log("GAME IS WIN");
                    TrapsEffects.instanceTrapsEffects.TrapSelector(1);
                    GameManager.Instance.SpawnFortuneWheel();
                    StartCoroutine(DespawnAnimation());
                    Destroy(this.transform.parent.gameObject);

                }
                else if ((isP1Win && !isP2Win) || (!isP1Win && isP2Win))
                {
                    // Game finish Semi-win
                    //Debug.Log("GAME IS SEMI-WIN");
                    TrapsEffects.instanceTrapsEffects.TrapSelector(2);
                    GameManager.Instance.SpawnFortuneWheel();
                    StartCoroutine(DespawnAnimation());
                    Destroy(this.transform.parent.gameObject);
                }
                else if (!isP1Win && !isP2Win)
                {
                    // Game finish lose
                    //Debug.Log("GAME IS LOSE");
                    StartCoroutine(GameFinishLose());
                    /*GameManager.Instance.SpawnFortuneWheel();
                    StartCoroutine(DespawnAnimation());
                    Destroy(this.transform.parent.gameObject);*/
                }
            }
        }
        else
        {
            if (!isP1Playing)
            {
                if (isP1Win)
                {
                    TrapsEffects.instanceTrapsEffects.TrapSelector(1);
                    GameManager.Instance.SpawnFortuneWheel();
                    StartCoroutine(DespawnAnimation());
                    Destroy(this.transform.parent.gameObject);
                }
            }
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
                //Debug.Log("P1 a gagné!!!");
                isP1Win = true;
            }
            else
            {
                //Debug.Log("P1 a perdu!!!");
                isP1Win = false;
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
                //Debug.Log("P2 a gagné!!!");
                isP2Win = true;
            }
            else
            {
                //Debug.Log("P2 a perdu!!!");
                isP2Win = false;
            }
        }
        else
        {
            if (handlePosP2.x < (intervalP2.transform.localPosition + ((Vector3)intervalP2Size / 2)).x && handlePosP2.x > (intervalP2.transform.localPosition - ((Vector3)intervalP2Size / 2)).x)
            {
                //Debug.Log("P2 a gagné!!!");
                isP2Win = true;
            }
            else
            {
                //Debug.Log("P2 a perdu!!!");
                isP2Win = false;
            }
        }

    }
}
