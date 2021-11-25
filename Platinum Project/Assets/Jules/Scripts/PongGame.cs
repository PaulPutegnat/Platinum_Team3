using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PongGame : MonoBehaviour
{
    public GameObject _PongBarP1GameObject;
    public GameObject _PongBarP2GameObject;
    public GameObject _BallGameObject;
    public float _PongBarSpeed;
    public float _BallSpeed;
    

    private Vector2 inputValueP1;
    private Vector2 inputValueP2;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;
    private Rigidbody2D rbBall;

    private PlayerInput pongInputP1;
    private PlayerInput pongInputP2;
    private bool IsTwoPlayer = false;

    void Start()
    {
        //pongInputP1 = GameManager.gameManager.players[2].GetComponent<PlayerInput>();
        if (GameManager.gameManager.players[3] != null)
        {
            IsTwoPlayer = true;
            //pongInputP2 = GameManager.gameManager.players[3].GetComponent<PlayerInput>();
        }
        else
        {
            IsTwoPlayer = false;
        }

        rb1 = _PongBarP1GameObject.GetComponent<Rigidbody2D>();
        rb2 = _PongBarP2GameObject.GetComponent<Rigidbody2D>();
        rbBall = _BallGameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (IsTwoPlayer)
        {
            inputValueP1 = InputManager.inputManager.PongDuoP1();
            inputValueP2 = InputManager.inputManager.PongDuoP2();
            MoveP1PongBar(inputValueP1);
            MoveP2PongBar(inputValueP2);
        }
        else
        {
            inputValueP1 = InputManager.inputManager.PongSoloLeft();
            inputValueP2 = InputManager.inputManager.PongSoloRight();
            MoveP1PongBar(inputValueP1);
            MoveP2PongBar(inputValueP2);
        }
    }

    public void MoveP1PongBar(Vector2 newPos)
    {
        rb1.velocity = new Vector2(rb1.velocity.x, newPos.y * _PongBarSpeed * Time.deltaTime);
    }
    
    public void MoveP2PongBar(Vector2 newPos)
    {
        rb2.velocity = new Vector2(rb2.velocity.x, newPos.y * _PongBarSpeed * Time.deltaTime);
    }

    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rbBall.velocity = new Vector2(_BallSpeed * x, _BallSpeed * y);
    }
}
