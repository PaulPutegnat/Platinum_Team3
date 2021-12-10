using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapsEffects : MonoBehaviour
{
    public static TrapsEffects instanceTrapsEffects;
    public Image BrokenScreen;
    [HideInInspector] public int trapNum;

    [Range(0f, 10f)] public float BrokenScreenDuration = 3;
    [Range(0f, 10f)] public float BrokenScreenFadeInSpeed = 4;
    [Range(0f, 10f)] public float BrokenScreenFadeOutSpeed = 1;
    [Range(0f, 10f)] public float speedMultiplicator = 2;
    [Range(0f, 10f)] public float speedTrapDuration = 2;
    [Range(0f, 5f)] public float shakeTrapDuration = 1.5f;
    [Range(0f, 3f)] public float shakeTrapMagnitude = 0.4f;

    public TestCam _testcam;

    private void Awake()
    {
        if (instanceTrapsEffects != null && instanceTrapsEffects != this)
            Destroy(gameObject);

        instanceTrapsEffects = this;
    }

    private void Start()
    {
        _testcam = FindObjectOfType<Camera>().GetComponent<TestCam>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TrapSelector(1);
        }
    }

    public void TrapSelector(float semiWinSplit)
    {
        if (trapNum == 1)
        {
            StartCoroutine(CameraSpeedTrap(semiWinSplit));
        }
        if (trapNum == 2)
        {
            StartCoroutine(BrokenScreenTrap(semiWinSplit));
        }
        if (trapNum == 3)
        {
            StartCoroutine(CameraShakeTrap(shakeTrapDuration, shakeTrapMagnitude));
        }
    }

    public IEnumerator CameraSpeedTrap(float semiWinSplitRef)
    {
        Debug.Log("Speed Up!");
        _testcam.speedUp = speedMultiplicator  / semiWinSplitRef;
        yield return new WaitForSeconds(speedTrapDuration / semiWinSplitRef);
        _testcam.speedUp = 1;
    }

    public IEnumerator BrokenScreenTrap(float semiWinSplitRef)
    {
        Debug.Log("BrokenScreenTrap");
        Color objectColor = BrokenScreen.color;
        float fadeAmount = objectColor.a;

        while (BrokenScreen.color.a < 1)
        {
            fadeAmount +=  BrokenScreenFadeInSpeed * Time.deltaTime;

            objectColor = new Color(BrokenScreen.color.r, BrokenScreen.color.g, BrokenScreen.color.b, fadeAmount);
            BrokenScreen.color = objectColor;
            yield return null;
        }

        yield return new WaitForSeconds(BrokenScreenDuration / semiWinSplitRef);

        while (BrokenScreen.color.a > 0)
        {
            fadeAmount -= BrokenScreenFadeOutSpeed * Time.deltaTime;

            objectColor = new Color(BrokenScreen.color.r, BrokenScreen.color.g, BrokenScreen.color.b, fadeAmount);
            BrokenScreen.color = objectColor;
            yield return null;
        }
    }

    public IEnumerator CameraShakeTrap(float duration, float magnitude)
    {
        Debug.Log("CameraShakeTrap");
        Vector3 originalPos = Camera.main.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = originalPos;
    }
}
