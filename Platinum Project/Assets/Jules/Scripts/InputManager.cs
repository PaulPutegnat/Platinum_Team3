using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager inputManager;

    public PlayerInput P1RunnerInput;
    public PlayerInput P2RunnerInput;
    public PlayerInput P1TrapperInput;
    public PlayerInput P2TrapperInput;

    private bool isAlreadySet = false;

    private void Awake()
    {
        if (inputManager != null && inputManager != this)
            Destroy(gameObject);

        inputManager = this;
    }

    private void Update()
    {
        if (GameManager.Instance.IsBegin && !isAlreadySet)
        {
            if (GameManager.Instance.players[0])
            {
                P1RunnerInput = GameManager.Instance.players[0].GetComponent<PlayerInput>();
            }
            
            if (GameManager.Instance.players[1])
            {
                P2RunnerInput = GameManager.Instance.players[1].GetComponent<PlayerInput>();
            }

            if (GameManager.Instance.players[2])
            {
                P1TrapperInput = GameManager.Instance.players[2].GetComponent<PlayerInput>();
            }

            if (GameManager.Instance.players[3])
            {
                P2TrapperInput = GameManager.Instance.players[3].GetComponent<PlayerInput>();
            }

            isAlreadySet = true;
        }
    }

    #region Shooting
    public bool ShootP1()
    {
        return P1TrapperInput.actions.FindAction("Shoot").triggered;
    }
    public bool ShootP2()
    {
        return P2TrapperInput.actions.FindAction("Shoot").triggered;
    }

    public Vector2 AimShooterP1()
    {
        return P1TrapperInput.actions.FindAction("Aiming").ReadValue<Vector2>();
    }
    public Vector2 AimShooterP2()
    {
        return P2TrapperInput.actions.FindAction("Aiming").ReadValue<Vector2>();
    }

    #endregion

    #region SpamQTE

    public bool SpamQTEDuoP1()
    {
        return P1TrapperInput.actions.FindAction("SpamQTEDuo").triggered;
    }
    public bool SpamQTEDuoP2()
    {
        return P2TrapperInput.actions.FindAction("SpamQTEDuo").triggered;
    }
    
    public bool SpamQTESoloLeft()
    {
        return P1TrapperInput.actions.FindAction("SpamQTESoloLeft").triggered;
    }
    public bool SpamQTESoloRight()
    {
        return P1TrapperInput.actions.FindAction("SpamQTESoloRight").triggered;
    }



    #endregion

    #region Sliding

    public bool SlidingStopP1()
    {
        return P1TrapperInput.actions.FindAction("SlidingBar").triggered;
    }
    public bool SlidingStopP2()
    {
        return P2TrapperInput.actions.FindAction("SlidingBar").triggered;
    }

    #endregion

    #region Pong

    public Vector2 PongDuoP1()
    {
        return P1TrapperInput.actions.FindAction("Pong").ReadValue<Vector2>();
    }
    public Vector2 PongDuoP2()
    {
        return P2TrapperInput.actions.FindAction("Pong").ReadValue<Vector2>();
    } 
    public Vector2 PongSoloLeft()
    {
        return P1TrapperInput.actions.FindAction("Pong").ReadValue<Vector2>();
    }
    public Vector2 PongSoloRight()
    {
        return P1TrapperInput.actions.FindAction("PongSoloRight").ReadValue<Vector2>();
    }

    #endregion

    #region Portal

    public bool PortalP1()
    {
        return P1RunnerInput.actions.FindAction("PortalSpam").triggered;
    }
    public bool PortalP2()
    {
        return P2RunnerInput.actions.FindAction("PortalSpam").triggered;
    }

    #endregion
}
