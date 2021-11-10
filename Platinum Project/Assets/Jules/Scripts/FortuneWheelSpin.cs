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

    public Transform parent;
    private Transform canvas;
    private float currentTime;
    private bool isAlreadyRotate = false;

    public AnimationCurve curve;

    public GameObject SlidingBarGame;
    public GameObject SpamQTEGame;

    private MiniGameGenerator GameGenerator;

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
        SetPositionData();
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        GameGenerator = FindObjectOfType<MiniGameGenerator>();
    }

    private void Update()
    {
        bool isButtonPressed = inputActions.Trapper.FortuneWheel.triggered;
        if (isButtonPressed && !isAlreadyRotate)
        {
            RotateNow();
            isAlreadyRotate = true;
        }
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



        if (indexGameRandom % 2 == 0) //even
        {
            GameObject spamFameGameObject = Instantiate(SpamQTEGame, Vector3.zero, Quaternion.identity, canvas);
            GameGenerator.gameList.Add(spamFameGameObject);
            spamFameGameObject.transform.localPosition = Vector3.zero;
            Destroy(this.parent.gameObject);
        }
        else //odd
        {
            GameObject slidGameObject = Instantiate(SlidingBarGame, Vector3.zero, Quaternion.identity, canvas);
            GameGenerator.gameList.Add(slidGameObject);
            slidGameObject.transform.localPosition = Vector3.zero;
            Destroy(this.parent.gameObject);
        }
    }

    [ContextMenu("Rotate")]
    void RotateNow()
    {
        StartCoroutine(RotateWheel());
    }

    void SetPositionData()
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            parent.GetChild(i).eulerAngles = new Vector3(0, 0, -CIRCLE / nbOfGames * i);
            parent.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }
}
