using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapsEffects : MonoBehaviour
{
    public static TrapsEffects instanceTrapsEffects;
    public Image BrokenScreen;

    [Range(0f, 10f)] public float BrokenScreenDuration = 3;
    [Range(0f, 10f)] public float BrokenScreenFadeInSpeed = 4;
    [Range(0f, 10f)] public float BrokenScreenFadeOutSpeed = 1;
    [Range(0f, 5f)] public float speedMultiplicator = 2;
    [Range(0f, 10f)] public float speedTrapDuration = 2;
    
    private TestCam _testcam;

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
            TrapSelector();
        }
    }

    public void TrapSelector()
    {
        float trapNum = Random.Range(1, 4);
        if (trapNum == 1)
        {
            StartCoroutine(CameraSpeedTrap());
        }
        if (trapNum == 2)
        {
            StartCoroutine(BrokenScreenTrap());
        }
    }

    public IEnumerator CameraSpeedTrap()
    {
        Debug.Log("Speed Up!");
        _testcam.speedUp = speedMultiplicator;
        yield return new WaitForSeconds(speedTrapDuration);
        _testcam.speedUp = 1;
    }

    public IEnumerator BrokenScreenTrap()
    {
        Color objectColor = BrokenScreen.color;
        float fadeAmount = objectColor.a;

        while (BrokenScreen.color.a < 1)
        {
            fadeAmount +=  BrokenScreenFadeInSpeed * Time.deltaTime;

            objectColor = new Color(BrokenScreen.color.r, BrokenScreen.color.g, BrokenScreen.color.b, fadeAmount);
            BrokenScreen.color = objectColor;
            yield return null;
        }

        yield return new WaitForSeconds(BrokenScreenDuration);

        while (BrokenScreen.color.a > 0)
        {
            fadeAmount -= BrokenScreenFadeOutSpeed * Time.deltaTime;

            objectColor = new Color(BrokenScreen.color.r, BrokenScreen.color.g, BrokenScreen.color.b, fadeAmount);
            BrokenScreen.color = objectColor;
            yield return null;
        }
    }
}
