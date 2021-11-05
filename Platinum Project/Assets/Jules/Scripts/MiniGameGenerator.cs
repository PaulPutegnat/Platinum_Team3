using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public enum DIRECTION_NAME
    {
        NONE,
        LEFT,
        RIGHT,
    }

    public enum PLAYER_NAME
    {
        NONE,
        J1,
        J2
    }

    public List<GameObject> gameList = new List<GameObject>();
    private GameObject miniGameObject;
    public MINIGAME gameName = MINIGAME.NONE;
    public PLAYER_NAME playerType = PLAYER_NAME.NONE;
    public DIRECTION_NAME directionType = DIRECTION_NAME.NONE;

    public Vector2 valueInputJ1 = Vector2.zero;
    public Vector2 valueInputJ2 = Vector2.zero;


    void Start()
    {
        switch (gameName)
        {
            case MINIGAME.SLIDING_GAME:

                break;

            case MINIGAME.SPAM_QTE_GAME:

                break;

            case MINIGAME.SHOOTING_GAME:

                break;

            case MINIGAME.PONG_GAME:
                miniGameObject = Instantiate(gameList[0], FindObjectOfType<Canvas>().transform); // dictionnaire avec joeur + gameObject
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
    }


    void Update()
    {
        string inputNameX = string.Format("{0}_{1}_{2}", playerType.ToString(), "HORIZONTAL", directionType.ToString());
        string inputNameY = string.Format("{0}_{1}_{2}", playerType.ToString(), "VERTICAL", directionType.ToString());

        float jAxisXJ1 = Input.GetAxis(inputNameX);
        float jAxisYJ1 = Input.GetAxis(inputNameY);
        Vector2 vectorInput = new Vector2(jAxisXJ1, jAxisYJ1);

        if (vectorInput != Vector2.zero)
        {
            valueInputJ1 = new Vector2(jAxisXJ1, jAxisYJ1);
        }
        else
        {
            valueInputJ1 = Vector2.zero;
        }

        switch (gameName)
        {
            case MINIGAME.SLIDING_GAME:

                break;

            case MINIGAME.SPAM_QTE_GAME:

                break;

            case MINIGAME.SHOOTING_GAME:

                break;

            case MINIGAME.PONG_GAME:
                miniGameObject.GetComponent<PongGame>().MovePongBar(valueInputJ1);
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
    }
}
