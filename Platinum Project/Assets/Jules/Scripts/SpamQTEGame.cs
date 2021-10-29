using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEditor.Rendering;

public class SpamQTEGame : MonoBehaviour
{
    enum PlayerTurnState
    {
        P1,
        P2
    }

    private PlayerControls inputActions;

    [Header("GameObjects")]
    public Slider spamSlider;
    public Slider timeSlider;
    public GameObject timerFillArea;
    public GameObject buttonP1;
    public GameObject buttonP2;

    private Image buttonP1Sprite;
    private Image buttonP2Sprite;

    [Header("Timer Value")]
    public float gameDuration;
    public float intervalTime;
    private float ShakeTimer;
    public TextMeshProUGUI timerText;
    private Color timerColor;

    [Header("SpamGame Value")]
    public float sliderMaxValue;
    public float sliderCurrentValue;
    public float decreaseSpeed;

    private bool p1ButtonPressed;
    private bool p2ButtonPressed;

    private PlayerTurnState _state;
    

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

    void Start()
    {
        timeSlider.maxValue = gameDuration;

        spamSlider.maxValue = sliderMaxValue;
        sliderCurrentValue = sliderMaxValue;
        timerText.text = gameDuration.ToString();

        buttonP1Sprite = buttonP1.GetComponent<Image>();
        buttonP2Sprite = buttonP2.GetComponent<Image>();

        timerFillArea.GetComponent<Image>().color = Color.green;
        

    }


    void Update()
    {
        p1ButtonPressed = inputActions.Trapper.SpamQTEP1.triggered;
        p2ButtonPressed = inputActions.Trapper.SpamQTEP2.triggered;

        switch (_state)
        {
            case PlayerTurnState.P1:
                if (p1ButtonPressed)
                {
                    sliderCurrentValue += 2f;
                    _state = PlayerTurnState.P2;
                    buttonP1Sprite.sprite = Resources.Load<Sprite>("Sprites/AButtonP1Smashed");
                }
                else
                {
                    buttonP1Sprite.sprite = Resources.Load<Sprite>("Sprites/AButtonP1");
                }
                break;

            case PlayerTurnState.P2:
                if (p2ButtonPressed)
                {
                    sliderCurrentValue += 2f;
                    _state = PlayerTurnState.P1;
                    buttonP2Sprite.sprite = Resources.Load<Sprite>("Sprites/AButtonP2Smashed");
                }
                else
                {
                    buttonP2Sprite.sprite = Resources.Load<Sprite>("Sprites/AButtonP2");
                }
                break;
        }

        if (spamSlider.value > 0)
        {
            spamSlider.value = sliderCurrentValue;
            sliderCurrentValue -= Time.deltaTime * decreaseSpeed;
            if (sliderCurrentValue >= sliderMaxValue)
            {
                sliderCurrentValue = sliderMaxValue;
            }
        }

        if (gameDuration > 0)
        {
            if (gameDuration < 15f)
            {
                timerFillArea.GetComponent<Image>().color = new Color(1, .5f, 0);
                if (gameDuration < 5)
                {
                    timerFillArea.GetComponent<Image>().color = Color.red;
                }
            }
            timeSlider.value = gameDuration;
            gameDuration -= Time.deltaTime;
        }
        else
        {
            // Game Finish
            Debug.Log("Game Finish !");
        }

        if (ShakeTimer > intervalTime)
        {
            // CameraShake en fonction de la valeur de la barre de spam
            if (spamSlider.value > 25)
            {
                //CameraShake Puissance 5
                Debug.Log("CameraShake Puissance 5");
            }
            else if (spamSlider.value > 20)
            {
                //CameraShake Puissance 4
                Debug.Log("CameraShake Puissance 4");
            }
            else if (spamSlider.value > 15)
            {
                //CameraShake Puissance 3
                Debug.Log("CameraShake Puissance 3");
            }
            else if (spamSlider.value > 10)
            {
                //CameraShake Puissance 2
                Debug.Log("CameraShake Puissance 2");
            }
            else
            {
                //CameraShake Puissance 1
                Debug.Log("CameraShake Puissance 1");
            }

            ShakeTimer = 0;
        }

        ShakeTimer += Time.deltaTime;
        timerText.text = gameDuration.ToString("f2");
    }
}
