using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameGenerator : MonoBehaviour
{
    public enum MINIGAME // a changer en list pour pouvoir en rajouter
    {
        NONE,
        SLIDING_GAME,
        SPAM_QTE_GAME,
        SHOOTING_GAME,
        PONG_GAME,
        PING_PONG_GAME,
        WATER_IS_COMING_GAME,
        BIRDS_COUNTING_GAME,
        GUITAR_HERO_GAME
    }
    public enum SLIDING
    {
        NONE,
        P1_BUTTON,
        P2_BUTTON
    }
    public enum SPAM_QTE
    {
        NONE,
    }
    public enum SHOOTING
    {
        NONE,
    }
    public enum PONG
    {
        NONE,
        LEFT_BAR,
        RIGHT_BAR,
    }
    public enum PINGPONG
    {
        NONE,
    }
    public enum WATER
    {
        NONE,
    }
    public enum BIRDS
    {
        NONE,
    }
    public enum GUITAR_HERO
    {
        NONE,
    }

    public enum PLAYER_NAME
    {
        NONE,
        J1,
        J2
    }
    public enum KEY
    {
        NONE,
        JOYSTICK,
        DIRECTIONAL_BUTTON,
        SHOULDER_BUTTON,
        SHOULDER_TRIGGER,
        START,
        SELECT
    }
    public enum SIDE_KEY
    {
        NONE,
        LEFT,
        RIGHT
    }

    private PlayerControls playerControls;
    public List<GameObject> gameList = new List<GameObject>();
    private GameObject miniGameObject;

    [Header("MINIGAME")]
    public MINIGAME gameName = MINIGAME.NONE;
    public SLIDING slidingGameObject = SLIDING.NONE;
    public SPAM_QTE spamQTEGameObject = SPAM_QTE.NONE;
    public SHOOTING ShootingGameObject = SHOOTING.NONE;
    public PONG pongGameObject = PONG.NONE;
    public PINGPONG pingpongGameObject = PINGPONG.NONE;
    public WATER waterGameObject = WATER.NONE;
    public BIRDS birdsGameObject = BIRDS.NONE;
    public GUITAR_HERO GuitarHeroGameObject = GUITAR_HERO.NONE;

    [Header("PLAYERS & KEYS")]
    public PLAYER_NAME playerType = PLAYER_NAME.NONE;
    public KEY keyType = KEY.NONE;
    public SIDE_KEY sideKey = SIDE_KEY.NONE;

    [Header("VALUE")]
    public Vector2 valueInputJ1 = Vector2.zero;

    private bool IsInstantiate = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        
    }


    void Update()
    {

        if (GameManager.gameManager.IsBegin)
        {
            switch (gameName)
            {
                case MINIGAME.SLIDING_GAME:
                    miniGameObject = Instantiate(gameList[0], GameObject.FindGameObjectWithTag("Canvas").transform);
                    break;

                case MINIGAME.SPAM_QTE_GAME:
                    miniGameObject = Instantiate(gameList[1], GameObject.FindGameObjectWithTag("Canvas").transform);
                    break;

                case MINIGAME.SHOOTING_GAME:
                    miniGameObject = Instantiate(gameList[2], GameObject.FindGameObjectWithTag("Canvas").transform);
                    break;

                case MINIGAME.PONG_GAME:
                    miniGameObject = Instantiate(gameList[3], GameObject.FindGameObjectWithTag("Canvas").transform); // dictionnaire avec joeur + gameObject
                    break;

                case MINIGAME.PING_PONG_GAME:
                    miniGameObject = Instantiate(gameList[4], FindObjectOfType<Canvas>().transform);
                    break;

                case MINIGAME.WATER_IS_COMING_GAME:
                    miniGameObject = Instantiate(gameList[5], FindObjectOfType<Canvas>().transform);
                    break;

                case MINIGAME.BIRDS_COUNTING_GAME:
                    miniGameObject = Instantiate(gameList[6], FindObjectOfType<Canvas>().transform);
                    break;

                case MINIGAME.GUITAR_HERO_GAME:
                    miniGameObject = Instantiate(gameList[7], FindObjectOfType<Canvas>().transform);
                    break;

                default:
                    return;
                    break;
            }
            IsInstantiate = true;
        }

        //string inputNameX = string.Format("{0}_{1}_{2}", playerType.ToString(), "HORIZONTAL", sideJey.ToString());
        //string inputNameY = string.Format("{0}_{1}_{2}", playerType.ToString(), "VERTICAL", sideJey.ToString());

        //float jAxisXJ1 = Input.GetAxis(inputNameX);
        //float jAxisYJ1 = Input.GetAxis(inputNameY);


        Vector2 vectorInput = playerControls.Trapper.LeftJoystick.ReadValue<Vector2>();

        if (vectorInput != Vector2.zero)
        {
            valueInputJ1 = playerControls.Trapper.LeftJoystick.ReadValue<Vector2>();
        }
        else
        {
            valueInputJ1 = Vector2.zero;
        }

        /*switch (gameName)
        {
            case MINIGAME.SLIDING_GAME:

                break;

            case MINIGAME.SPAM_QTE_GAME:

                break;

            case MINIGAME.SHOOTING_GAME:

                break;

            case MINIGAME.PONG_GAME:
                //miniGameObject.GetComponent<PongGame>().MoveP1PongBar(valueInputJ1);
                break;

            case MINIGAME.PING_PONG_GAME:

                break;

            case MINIGAME.WATER_IS_COMING_GAME:

                break;

            case MINIGAME.BIRDS_COUNTING_GAME:

                break;

            case MINIGAME.GUITAR_HERO_GAME:

                break;

            default:
                break;
        }*/

        if (IsInstantiate && !GameManager.gameManager.IsBegin)
        {
            if (playerType == PLAYER_NAME.J1)
            {
                switch (keyType)
                {
                    case KEY.JOYSTICK:

                        switch (sideKey)
                        {
                            case SIDE_KEY.LEFT:
                                switch (gameName)
                                {
                                    case MINIGAME.SLIDING_GAME:

                                        break;

                                    case MINIGAME.SPAM_QTE_GAME:

                                        break;

                                    case MINIGAME.SHOOTING_GAME:

                                        break;

                                    case MINIGAME.PONG_GAME:
                                        switch (pongGameObject)
                                        {
                                            case PONG.LEFT_BAR:
                                                miniGameObject.GetComponent<PongGame>().MoveP1PongBar(playerControls.Trapper.LeftJoystick.ReadValue<Vector2>());
                                                break;

                                            case PONG.RIGHT_BAR:
                                                miniGameObject.GetComponent<PongGame>().MoveP2PongBar(playerControls.Trapper.LeftJoystick.ReadValue<Vector2>());
                                                break;
                                        }
                                        break;

                                    case MINIGAME.PING_PONG_GAME:

                                        break;

                                    case MINIGAME.WATER_IS_COMING_GAME:

                                        break;

                                    case MINIGAME.BIRDS_COUNTING_GAME:

                                        break;

                                    case MINIGAME.GUITAR_HERO_GAME:

                                        break;

                                    default:
                                        break;
                                }
                                break;

                            case SIDE_KEY.RIGHT:
                                switch (gameName)
                                {
                                    case MINIGAME.SLIDING_GAME:

                                        break;

                                    case MINIGAME.SPAM_QTE_GAME:

                                        break;

                                    case MINIGAME.SHOOTING_GAME:

                                        break;

                                    case MINIGAME.PONG_GAME:
                                        switch (pongGameObject)
                                        {
                                            case PONG.LEFT_BAR:
                                                miniGameObject.GetComponent<PongGame>().MoveP1PongBar(playerControls.Trapper.RightJoystick.ReadValue<Vector2>());
                                                break;

                                            case PONG.RIGHT_BAR:
                                                miniGameObject.GetComponent<PongGame>().MoveP2PongBar(playerControls.Trapper.RightJoystick.ReadValue<Vector2>());
                                                break;
                                        }
                                        break;

                                    case MINIGAME.PING_PONG_GAME:

                                        break;

                                    case MINIGAME.WATER_IS_COMING_GAME:

                                        break;

                                    case MINIGAME.BIRDS_COUNTING_GAME:

                                        break;

                                    case MINIGAME.GUITAR_HERO_GAME:

                                        break;

                                    default:
                                        break;
                                }
                                break;
                        }
                        break;

                    case KEY.DIRECTIONAL_BUTTON:

                        break;

                    case KEY.SHOULDER_BUTTON:

                        break;

                    case KEY.SHOULDER_TRIGGER:

                        break;

                    case KEY.START:

                        break;

                    case KEY.SELECT:

                        break;

                    default:
                        break;
                }
            }
            else
            {

            }
        }
        

        
    }
}
