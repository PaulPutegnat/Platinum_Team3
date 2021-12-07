using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class neutralcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Comfirmation = false;
    private STATE _state;
    private int limit = 1;
    private GameObject runnerRef;
    private GameObject TrapperRef;
    private RectTransform thisRT;
    private Transform R1;
    private Transform R2;
    private Transform T1;
    private Transform T2;
    private Transform J1;
    private Transform J2;
    private Transform J3;
    private Transform J4;
    enum STATE
    {
        RUNNER,
        TRAPPER,
        MIDDLE
    }

    private void Awake()
    {
        //Debug.Log(GameManager.Instance.gameObject.GetComponent<PlayerInputManager>().playerCount);
        
    }

    private void Start()
    {
        transform.SetParent(GameObject.Find("Canvas").transform);
        thisRT = GetComponent<RectTransform>();
        thisRT.localScale = Vector3.one;
        thisRT.localPosition = new Vector3(0, 300, 0);
        thisRT.localRotation = Quaternion.identity;
        R1 = GameObject.FindGameObjectWithTag("R1").transform;
        R2 = GameObject.FindGameObjectWithTag("R2").transform;
        T1 = GameObject.FindGameObjectWithTag("T1").transform;
        T2 = GameObject.FindGameObjectWithTag("T2").transform;
        J1 = GameObject.FindGameObjectWithTag("J1").transform;
        J2 = GameObject.FindGameObjectWithTag("J2").transform;
        J3 = GameObject.FindGameObjectWithTag("J3").transform;
        J4 = GameObject.FindGameObjectWithTag("J4").transform;
        TextMeshProUGUI playerText = GetComponent<TextMeshProUGUI>();
        switch (GameManager.Instance.gameObject.GetComponent<PlayerInputManager>().playerCount)
        {
            case 1:
                transform.SetParent(J1, false);
                transform.localPosition = Vector3.zero;
                playerText.text = "J1";
                break;

            case 2:
                transform.SetParent(J2, false);
                transform.localPosition = Vector3.zero;
                playerText.text = "J2";
                break;

            case 3:
                transform.SetParent(J3, false);
                transform.localPosition = Vector3.zero;
                playerText.text = "J3";
                break;

            case 4:
                transform.SetParent(J4, false);
                transform.localPosition = Vector3.zero;
                playerText.text = "J4";
                break;
        }

        _state = STATE.MIDDLE;
    }

    public void ChangeTeam(InputAction.CallbackContext context)
    {
        if (!Comfirmation)
        {
            Vector2 dir = context.ReadValue<Vector2>();
            if (dir.x < -0.25f)
            {
                switch (_state)
                {
                    case STATE.MIDDLE:
                        if (GetComponent<RectTransform>().anchoredPosition.x == 0 && R1.transform.childCount == 0)
                        {
                            GameManager.Instance.RunnererNumber++;
                            transform.SetParent(R1, false);
                            GetComponent<RectTransform>().localPosition = Vector3.zero;
                        }
                        else
                        {
                            GameManager.Instance.RunnererNumber++;
                            transform.SetParent(R2, false);
                            GetComponent<RectTransform>().localPosition = Vector3.zero;
                        }
                        _state = STATE.RUNNER;
                        break;
                    case STATE.TRAPPER:
                        GameManager.Instance.TrapperNumber--;
                        switch (GetComponent<PlayerInput>().playerIndex)
                        {
                            case 0:
                                transform.SetParent(J1, false);
                                transform.localPosition = Vector3.zero;
                                break;

                            case 1:
                                transform.SetParent(J2, false);
                                transform.localPosition = Vector3.zero;
                                break;

                            case 2:
                                transform.SetParent(J3, false);
                                transform.localPosition = Vector3.zero;
                                break;

                            case 3:
                                transform.SetParent(J4, false);
                                transform.localPosition = Vector3.zero;
                                break;
                        }
                        _state = STATE.MIDDLE;
                        break;
                }
            }


            if (dir.x > 0.25f && GetComponent<RectTransform>().localPosition.x <= 0)
            {
                switch (_state)
                {
                    case STATE.MIDDLE:
                        if (GetComponent<RectTransform>().anchoredPosition.x == 0 && T1.transform.childCount == 0)
                        {
                            GameManager.Instance.TrapperNumber++;
                            transform.SetParent(T1, false);
                            GetComponent<RectTransform>().localPosition = Vector3.zero;
                        }
                        else
                        {
                            GameManager.Instance.TrapperNumber++;
                            transform.SetParent(T2, false);
                            GetComponent<RectTransform>().localPosition = Vector3.zero;
                        }
                        _state = STATE.TRAPPER;
                        break;
                    case STATE.RUNNER:
                        GameManager.Instance.TrapperNumber--;
                        switch (GetComponent<PlayerInput>().playerIndex)
                        {
                            case 0:
                                transform.SetParent(J1, false);
                                transform.localPosition = Vector3.zero;
                                break;

                            case 1:
                                transform.SetParent(J2, false);
                                transform.localPosition = Vector3.zero;
                                break;

                            case 2:
                                transform.SetParent(J3, false);
                                transform.localPosition = Vector3.zero;
                                break;

                            case 3:
                                transform.SetParent(J4, false);
                                transform.localPosition = Vector3.zero;
                                break;
                        }
                        _state = STATE.MIDDLE;
                        break;
                }
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