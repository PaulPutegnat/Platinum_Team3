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

    private PlayerControls inputActions;

    [Header("GameObjects")]
    public Slider spamSlider;
    public Slider timeSlider;
    public GameObject timerFillArea;
    public GameObject P1Hammer;
    public GameObject P2Hammer;
    public GameObject button;

    private Image P1HammerSprite;
    private Image P2HammerSprite;
    private Image ButtonSprite;

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

    private PlayerInput trapperInput1;
    private PlayerInput trapperInput2;

    private PlayerTurnState _state = PlayerTurnState.P1;
    private bool IsTwoPlayer = false;
    

    IEnumerator Start()
    {
        yield return StartCoroutine(SpawnAnimation());

        timeSlider.maxValue = gameDuration;
        ShakeTimer = 0f;
        spamSlider.maxValue = sliderMaxValue;
        spamSlider.value = 1f;
        timerText.text = gameDuration.ToString();

        P1HammerSprite = P1Hammer.GetComponent<Image>();
        P2HammerSprite = P2Hammer.GetComponent<Image>();
        ButtonSprite = button.GetComponent<Image>();

        timerColor = timerFillArea.GetComponent<Image>().color;
        timerColor = Color.green;

        //trapperInput1 = GameManager.Instance.players[2].GetComponent<PlayerInput>();
        if (GameManager.Instance.players[3] != null)
        {
            IsTwoPlayer = true;
            //trapperInput2 = GameManager.Instance.players[3].GetComponent<PlayerInput>();
        }
        else
        {
            IsTwoPlayer = false;
        }

        if (IsTwoPlayer)
        {
            switch (_state)
            {
                case PlayerTurnState.P2:
                    P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    break;

                case PlayerTurnState.P1:
                    P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    break;
            }
        }
        else
        {
            switch (_state)
            {
                case PlayerTurnState.P2:
                    P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    break;

                case PlayerTurnState.P1:
                    P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    break;
            }
        }
        

    }

    void Update()
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
                        P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    }
                    else
                    {
                        P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    }
                    break;

                case PlayerTurnState.P2:
                    if (p2ButtonPressed)
                    {

                        sliderCurrentValue += 2f;
                        _state = PlayerTurnState.P1;
                        P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");

                    }
                    else
                    {
                        P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
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
                        P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    }
                    else
                    {
                        P1HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    }
                    break;

                case PlayerTurnState.P2:
                    if (p2ButtonPressed)
                    {

                        sliderCurrentValue += 2f;
                        _state = PlayerTurnState.P1;
                        P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");

                    }
                    else
                    {
                        P2HammerSprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
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
            Debug.Log("Game Finish !");
            GameManager.Instance.SpawnFortuneWheel();
            Destroy(this.gameObject);
            
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
        spamSlider.value = sliderCurrentValue;

    }
}
