using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class neutralcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    private float posTrapper = 517f;
    private float posRunner = -459f;
    private bool Comfirmation = false;
    private STATE State;
    private bool IsActivated = false;
    private int limit = 1;
    enum STATE
    {
        RUNNER,
        TRAPPER
    }

    public void ChangeTeam(InputAction.CallbackContext context)
    {
        if (!Comfirmation)
        {
                float y = GetComponent<RectTransform>().anchoredPosition.y;
                Vector2 dir = context.ReadValue<Vector2>();
                if (dir.x < -0.25f)
                {
                    if (GetComponent<RectTransform>().anchoredPosition.x == 0)
                    {
                         GameManager.gameManager.RunnererNumber++;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(posRunner, y, 0);               
                    }
                    else
                    {
                        GameManager.gameManager.TrapperNumber--;
                        GameManager.gameManager.RunnererNumber++;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(posRunner, y, 0);
                    }

                    State = STATE.RUNNER;

                }
                

                if (dir.x > 0.25f)
                {
                    if (GetComponent<RectTransform>().anchoredPosition.x == 0)
                    {
                        GameManager.gameManager.TrapperNumber++;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(posTrapper, y, 0);                
                    }
                    else
                    { 
                        GameManager.gameManager.TrapperNumber++;
                        GameManager.gameManager.RunnererNumber--;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(posTrapper, y, 0);               
                    }
                    State = STATE.TRAPPER;
                }

        }
    }
        

    public void Confirmation(InputAction.CallbackContext context)
    {
        Comfirmation = true;
    }
    public void Back(InputAction.CallbackContext context)
    {
        Comfirmation = false;
    }

    public void InitPlayer()
    {
        if (limit == 1)
        {
            limit--;
            Debug.Log("spawn");
            switch(State)
            {
                case STATE.RUNNER:
                    IsActivated = true;
                    transform.parent = null;
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.position = Vector3.zero;
                    Instantiate(GameManager.gameManager.Runner.gameObject, GameManager.gameManager.spawn.position, Quaternion.identity, gameObject.transform);
                    if (GameManager.gameManager.players[0] = null)
                    {
                        GameManager.gameManager.players[0] = this.gameObject;
                    }
                    else
                    {
                        GameManager.gameManager.players[1] = this.gameObject;
                    }

                    break;

                case STATE.TRAPPER:
                    IsActivated = true;
                    transform.parent = null;
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.position = Vector3.zero;
                    Instantiate(GameManager.gameManager.Trapper.gameObject, new Vector3(0, 0, 0) ,Quaternion.identity, gameObject.transform);
                    if (GameManager.gameManager.players[2] = null)
                    {
                        GameManager.gameManager.players[2] = this.gameObject;
                        GetComponentInChildren<TrapController>().initTrapper(2);
                    }
                    else
                    {
                        GameManager.gameManager.players[3] = this.gameObject;
                        GetComponentInChildren<TrapController>().initTrapper(3);
                    }

                    break;

                default:
                    Debug.LogError("ERREUR");
                    break;
            }
        }
           
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        GetComponentInChildren<TESTCONTROLER>()._movementInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        GetComponentInChildren<TESTCONTROLER>().jump = context.action.triggered;

    }
}
