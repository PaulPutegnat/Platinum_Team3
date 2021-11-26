using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

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
    public GameObject buttonP2;
    public GameObject hammerP1;
    public GameObject hammerP2;

    private Image buttonP2Sprite;
    private Image hammerP1Sprite;
    private Image hammerP2Sprite;

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
    

    void Start()
    {
        timeSlider.maxValue = gameDuration;
        ShakeTimer = 0f;
        spamSlider.maxValue = sliderMaxValue;
        spamSlider.value = 1f;
        timerText.text = gameDuration.ToString();

        buttonP2Sprite = buttonP2.GetComponent<Image>();
        hammerP1Sprite = hammerP1.GetComponent<Image>();
        hammerP2Sprite = hammerP2.GetComponent<Image>();

        timerColor = timerFillArea.GetComponent<Image>().color;
        timerColor = Color.green;

        if (GameManager.gameManager.players[3] != null)
        {
            IsTwoPlayer = true;
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
                    buttonP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerBuzzMiniJeu");
                    hammerP1Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    hammerP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    break;

                case PlayerTurnState.P1:
                    buttonP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerBuzzMiniJeu");
                    hammerP1Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    hammerP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    break;
            }
        }
        else
        {
            switch (_state)
            {
                case PlayerTurnState.P2:
                    buttonP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerBuzzMiniJeu");
                    hammerP1Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    hammerP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    break;

                case PlayerTurnState.P1:
                    buttonP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerBuzzMiniJeu");
                    hammerP1Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    hammerP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
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
                        hammerP1Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    }
                    else
                    {
                        hammerP1Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    }
                    break;

                case PlayerTurnState.P2:
                    if (p2ButtonPressed)
                    {

                        sliderCurrentValue += 2f;
                        _state = PlayerTurnState.P1;
                        buttonP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerBuzzMiniJeu");
                        hammerP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");

                    }
                    else
                    {
                        buttonP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerBuzzMiniJeu");
                        hammerP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
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
                        hammerP1Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");
                    }
                    else
                    {
                        hammerP1Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
                    }
                    break;

                case PlayerTurnState.P2:
                    if (p2ButtonPressed)
                    {

                        sliderCurrentValue += 2f;
                        _state = PlayerTurnState.P1;
                        buttonP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerBuzzMiniJeu");
                        hammerP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeStopMiniJeu");

                    }
                    else
                    {
                        buttonP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerBuzzMiniJeu");
                        hammerP2Sprite.sprite = Resources.Load<Sprite>("UI_PROJECT/HammerIconeGoMiniJeu");
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
            GameManager.gameManager.SpawnFortuneWheel();
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
