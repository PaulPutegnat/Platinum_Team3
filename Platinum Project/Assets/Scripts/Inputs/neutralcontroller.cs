using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class neutralcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    private float posTrapper = 517f;
    private float posRunner = -459f;
    private bool Comfirmation = false;
    private STATE _state;
    private bool IsActivated = false;
    private int limit = 1;
    private GameObject runnerRef;
    private GameObject TrapperRef;
    private RectTransform thisRT;

    private bool cameraIsMoov = false;
    enum STATE
    {
        RUNNER,
        TRAPPER
    }

    private void Awake()
    {
        //Debug.Log(GameManager.Instance.gameObject.GetComponent<PlayerInputManager>().playerCount);
        transform.SetParent(GameObject.Find("Canvas").transform);
        thisRT = GetComponent<RectTransform>();
        thisRT.localScale = Vector3.one;
        thisRT.localPosition = new Vector3(0, 300, 0);
        thisRT.localRotation = Quaternion.identity;
        switch (GameManager.Instance.gameObject.GetComponent<PlayerInputManager>().playerCount)
        {
            case 1:
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 300, 0);
                break;

            case 2:
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100, 0);
                break;

            case 3:
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);
                break;

            case 4:
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -300, 0);
                break;
        }
        

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
                    GameManager.Instance.RunnererNumber++;
                    GetComponent<RectTransform>().anchoredPosition = new Vector3(posRunner, y, 0);
                }
                else
                {
                    GameManager.Instance.TrapperNumber--;
                    GameManager.Instance.RunnererNumber++;
                    GetComponent<RectTransform>().anchoredPosition = new Vector3(posRunner, y, 0);
                }

                _state = STATE.RUNNER;

            }


            if (dir.x > 0.25f)
            {
                if (GetComponent<RectTransform>().anchoredPosition.x == 0)
                {
                    GameManager.Instance.TrapperNumber++;
                    GetComponent<RectTransform>().anchoredPosition = new Vector3(posTrapper, y, 0);
                }
                else
                {
                    GameManager.Instance.TrapperNumber++;
                    GameManager.Instance.RunnererNumber--;
                    GetComponent<RectTransform>().anchoredPosition = new Vector3(posTrapper, y, 0);
                }
                _state = STATE.TRAPPER;
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
            switch (_state)
            {
                case STATE.RUNNER:
                    IsActivated = true;
                    transform.SetParent(null);
                    /*transform.localScale = new Vector3(1, 1, 1);
                    transform.position = Vector3.zero;*/
                    runnerRef = Instantiate(GameManager.Instance.Runner.gameObject, GameManager.Instance.spawn.position, Quaternion.identity);
                    if (GameManager.Instance.players[0] == null)
                    {
                        GameManager.Instance.players[0] = gameObject;
                        GameManager.Instance.playersRefs[0] = runnerRef;

                    }
                    else if(GameManager.Instance.players[1] == null)
                    {
                        GameManager.Instance.players[1] = gameObject;
                        GameManager.Instance.playersRefs[1] = runnerRef;
                    }
                    else
                    {
                        Debug.LogError("IL Y A DEJA 2 RUNNERS");
                    }
                    GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                    InitRunner();



                    break;

                case STATE.TRAPPER:
                    IsActivated = true;
                    transform.SetParent(null);
                    /*transform.localScale = new Vector3(1, 1, 1);
                    transform.position = Vector3.zero;*/
                    TrapperRef = Instantiate(GameManager.Instance.Trapper.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
                    if (GameManager.Instance.players[2] == null)
                    {
                        GameManager.Instance.players[2] = gameObject;
                        GameManager.Instance.playersRefs[2] = TrapperRef;
                        TrapperRef.GetComponent<TrapController>().initTrapper(2);
                    }
                    else if(GameManager.Instance.players[3] == null)
                    {
                        GameManager.Instance.players[3] = gameObject;
                        GameManager.Instance.playersRefs[3] = TrapperRef;
                        TrapperRef.GetComponent<TrapController>().initTrapper(3);
                    }
                    else
                    {
                        Debug.LogError("IL Y A DEJA 2 TRAPPERS");
                    }
                    GetComponent<PlayerInput>().SwitchCurrentActionMap("Trapper");
                    InitTrapper();
                    break;

                default:
                    Debug.LogError("ERREUR");
                    break;
            }
        }

    }

    void InitRunner()
    {
        GameManager.Instance.ActivePlayer++;
        GameManager.Instance.checkUI();
        GetComponent<PlayerInput>().actions.FindAction("Echap").performed += new Action<InputAction.CallbackContext>(GameObject.Find("Pause").GetComponent<Pause>().PausePressed);
        GetComponent<PlayerInput>().actions.FindAction("Movement").performed += new Action<InputAction.CallbackContext>(runnerRef.GetComponent<TESTCONTROLER>().OnMove);
        GetComponent<PlayerInput>().actions.FindAction("Jump").performed += new Action<InputAction.CallbackContext>(runnerRef.GetComponent<TESTCONTROLER>().OnJump);
        GetComponent<PlayerInput>().actions.FindAction("Sliding").performed += new Action<InputAction.CallbackContext>(runnerRef.GetComponent<TESTCONTROLER>().OnSlide);
        runnerRef.SetActive(false);
    }

    void InitTrapper()
    {

        GameManager.Instance.ActivePlayer++;
        GameManager.Instance.checkUI();
        GetComponent<PlayerInput>().actions.FindAction("Echap").performed += new Action<InputAction.CallbackContext>(GameObject.Find("Pause").GetComponent<Pause>().PausePressed);
        TrapperRef.SetActive(false);
    }
}