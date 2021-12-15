using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class SpamQTEGame : MiniGame
{
    enum PlayerTurnState
    {
        P1,
        P2
    }

    [Header("GameObjects")]
    public Slider spamSlider;
    public Slider timeSlider;
    public GameObject timerFillArea;
    public GameObject P1Hammer;
    public GameObject P2Hammer;
    public GameObject P1Button;
    public GameObject P2Button;

    private Image P1HammerSprite;
    private Image P2HammerSprite;
    private Image P1ButtonSprite;
    private Image P2ButtonSprite;


    [Header("Timer Value")]
    public float gameDuration;
    public float intervalTime;
    private float ShakeTimer;
    public TextMeshProUGUI timerText;
    private Color timerColor;

    [Header("SpamGame Value")]
    public float sliderMaxValue;
    private float sliderCurrentValue;
    public float decreaseSpeed;

    private bool p1ButtonPressed;
    private bool p2ButtonPressed;

    private PlayerTurnState _state = PlayerTurnState.P1;
    private bool IsTwoPlayer = false;
    

    IEnumerator Start()
    {
        isGameBegin = false;
        IsGameFinishWinCoroutineStarted = false;
        IsGameFinishLoseCoroutineStarted = false;
        IsHammerCoroutineStarted = false;

        yield return StartCoroutine(SpawnAnimation());
        isGameBegin = true;

        timeSlider.maxValue = gameDuration;
        ShakeTimer = 0f;
        spamSlider.maxValue = sliderMaxValue;
        spamSlider.value = 1f;
        timerText.text = gameDuration.ToString();

        P1HammerSprite = P1Hammer.GetComponent<Image>();
        P2HammerSprite = P2Hammer.GetComponent<Image>();
        P1ButtonSprite = P1Button.GetComponent<Image>();
        P2ButtonSprite = P2Button.GetComponent<Image>();

        timerColor = timerFillArea.GetComponent<Image>().color;
        timerColor = Color.green;

        if (PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER2] != null)
        {
            IsTwoPlayer = true;
        }
        else
        {
            IsTwoPlayer = false;
        }

        switch (_state)
        {
            case PlayerTurnState.P2:
                P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer");
                P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer_Burst");
                P1ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A_Burst");
                P2ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A");
                break;

            case PlayerTurnState.P1:
                P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer");
                P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer_Burst");
                P2ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A_Burst");
                P1ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A");
                break;
        }
    }

    void Update()
    {
        if (isGameBegin)
        {
            if (IsTwoPlayer)
            {
                p1ButtonPressed = InputManager.inputManager.SpamQTEDuoP1();
                p2ButtonPressed = InputManager.inputManager.SpamQTEDuoP2();

                switch (_state)
                {
                    case PlayerTurnState.P1:
                        if (p1ButtonPressed)
                        {
                            sliderCurrentValue += 2f;
                            _state = PlayerTurnState.P2;
                            P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer");
                            P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer_Burst");
                            P1ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A_Burst");
                            P2ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A");
                        }
                        break;

                    case PlayerTurnState.P2:
                        if (p2ButtonPressed)
                        {
                            sliderCurrentValue += 2f;
                            _state = PlayerTurnState.P1;
                            P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer");
                            P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer_Burst");
                            P2ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A_Burst");
                            P1ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A");
                        }
                        break;
                }
            }
            else
            {
                p1ButtonPressed = InputManager.inputManager.SpamQTESoloLeft();
                p2ButtonPressed = InputManager.inputManager.SpamQTESoloRight();

                switch (_state)
                {
                    case PlayerTurnState.P1:
                        if (p1ButtonPressed)
                        {
                            sliderCurrentValue += 2f;
                            _state = PlayerTurnState.P2;
                            P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer");
                            P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer_Burst");
                            P1ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A_Burst");
                            P2ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A");
                        }
                        break;

                    case PlayerTurnState.P2:
                        if (p2ButtonPressed)
                        {
                            sliderCurrentValue += 2f;
                            _state = PlayerTurnState.P1;
                            P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer");
                            P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Hammer_Burst");
                            P2ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A_Burst");
                            P1ButtonSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/Hammer_Mini_Game/Button_A");
                        }
                        break;
                }
            }


            if (spamSlider.value > 0)
            {
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
                    timerColor = new Color(1, .5f, 0);
                    if (gameDuration < 5)
                    {
                        timerColor = Color.red;
                    }
                }
                timeSlider.value = gameDuration;
                gameDuration -= Time.deltaTime;
            }
            else
            {
                // Game Finish
                if (!IsHammerCoroutineStarted)
                {
                    StartCoroutine(HammerShake());
                }
            }

            if (ShakeTimer > intervalTime)
            {
                // CameraShake en fonction de la valeur de la barre de spam
                if (spamSlider.value > 25)
                {
                    //CameraShake Puissance 5
                    TrapsEffects.instanceTrapsEffects.StartCoroutine(TrapsEffects.instanceTrapsEffects.CameraShakeTrap(TrapsEffects.instanceTrapsEffects.shakeTrapDuration,
                                                                TrapsEffects.instanceTrapsEffects.shakeTrapMagnitude * 5));
                }
                else if (spamSlider.value > 20)
                {
                    //CameraShake Puissance 4
                    TrapsEffects.instanceTrapsEffects.StartCoroutine(TrapsEffects.instanceTrapsEffects.CameraShakeTrap(TrapsEffects.instanceTrapsEffects.shakeTrapDuration,
                                                                TrapsEffects.instanceTrapsEffects.shakeTrapMagnitude * 4));
                }
                else if (spamSlider.value > 15)
                {
                    //CameraShake Puissance 3
                    TrapsEffects.instanceTrapsEffects.StartCoroutine(TrapsEffects.instanceTrapsEffects.CameraShakeTrap(TrapsEffects.instanceTrapsEffects.shakeTrapDuration,
                                                                TrapsEffects.instanceTrapsEffects.shakeTrapMagnitude * 3));
                }
                else if (spamSlider.value > 10)
                {
                    //CameraShake Puissance 2
                    TrapsEffects.instanceTrapsEffects.StartCoroutine(TrapsEffects.instanceTrapsEffects.CameraShakeTrap(TrapsEffects.instanceTrapsEffects.shakeTrapDuration,
                                                                TrapsEffects.instanceTrapsEffects.shakeTrapMagnitude * 2));
                }
                else
                {
                    //CameraShake Puissance 1
                    TrapsEffects.instanceTrapsEffects.StartCoroutine(TrapsEffects.instanceTrapsEffects.CameraShakeTrap(TrapsEffects.instanceTrapsEffects.shakeTrapDuration,
                                                                        TrapsEffects.instanceTrapsEffects.shakeTrapMagnitude));
                }

                ShakeTimer = 0;
            }

            ShakeTimer += Time.deltaTime;
            timerText.text = gameDuration.ToString("f2");
            spamSlider.value = sliderCurrentValue;
        }
    }
}
