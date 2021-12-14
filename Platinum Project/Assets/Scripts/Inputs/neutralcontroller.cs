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
    [HideInInspector]public STATE _state;
    [HideInInspector]public int limit = 1;
    [HideInInspector] public GameObject runnerRef;
    [HideInInspector] public GameObject TrapperRef;
    private RectTransform thisRT;
    private Transform R1;
    private Transform R2;
    private Transform T1;
    private Transform T2;
    private Transform J1;
    private Transform J2;
    private Transform J3;
    private Transform J4;
    private Image controllerImage;
    private Image opaqueFilter;

    [HideInInspector]
    public enum STATE
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
        thisRT.localPosition = new Vector3(0, 300, 0);
        thisRT.localRotation = Quaternion.identity;
        if (GameObject.FindGameObjectWithTag("AEnlever") != null)
        {
            R1 = GameObject.FindGameObjectWithTag("R1").transform;
            R2 = GameObject.FindGameObjectWithTag("R2").transform;
            T1 = GameObject.FindGameObjectWithTag("T1").transform;
            T2 = GameObject.FindGameObjectWithTag("T2").transform;
            J1 = GameObject.FindGameObjectWithTag("J1").transform;
            J2 = GameObject.FindGameObjectWithTag("J2").transform;
            J3 = GameObject.FindGameObjectWithTag("J3").transform;
            J4 = GameObject.FindGameObjectWithTag("J4").transform;
        }

        controllerImage = GameObject.FindGameObjectWithTag("RendererNeutralPlayer").GetComponent<Image>();
        opaqueFilter = GameObject.FindGameObjectWithTag("OpaqueFilterNeutralPlayer").GetComponent<Image>();
        opaqueFilter.color = new Color(0f, 0f, 0f, 0f);
        switch (GameManager.Instance.gameObject.GetComponent<PlayerInputManager>().playerCount)
        {
            case 1:
                transform.SetParent(J1, false);
                transform.localPosition = Vector3.zero;
                controllerImage.color = new Color((58f / 255f), (72f / 255f), 1f);
                break;

            case 2:
                transform.SetParent(J2, false);
                transform.localPosition = Vector3.zero;
                controllerImage.color = new Color(1f, (109f / 255f), (64f / 255f));
                break;

            case 3:
                transform.SetParent(J3, false);
                transform.localPosition = Vector3.zero;
                controllerImage.color = new Color(1f, (64f / 255f), (118f / 255f));
                break;

            case 4:
                transform.SetParent(J4, false);
                transform.localPosition = Vector3.zero;
                controllerImage.color = new Color(1f, (222f / 255f), (92f / 255f));
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
                            _state = STATE.RUNNER;
                        }
                        else if(GetComponent<RectTransform>().anchoredPosition.x == 0 && R2.transform.childCount == 0)
                        {
                            GameManager.Instance.RunnererNumber++;
                            transform.SetParent(R2, false);
                            GetComponent<RectTransform>().localPosition = Vector3.zero;
                            _state = STATE.RUNNER;
                        }
                        
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
                            _state = STATE.TRAPPER;
                        }
                        else if(GetComponent<RectTransform>().anchoredPosition.x == 0 && T2.transform.childCount == 0)
                        {
                            GameManager.Instance.TrapperNumber++;
                            transform.SetParent(T2, false);
                            GetComponent<RectTransform>().localPosition = Vector3.zero;
                            _state = STATE.TRAPPER;
                        }
                        
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
        if (Comfirmation == false && _state != STATE.MIDDLE)
        {
            Comfirmation = true;
            GameManager.Instance.ActivePlayer++;
            GameManager.Instance.checkUI();
            controllerImage.sprite = Resources.Load<Sprite>("UI_PROJECT/Lock_Controller");
            opaqueFilter.color = new Color(0f, 0f, 0f, 0.8f);
            switch (_state)
            {
                case STATE.RUNNER:
                    if (PlayerManagerScript.Instance.players[PlayerManagerScript.RUNNER1] == null)
                    {
                        PlayerManagerScript.Instance.players[PlayerManagerScript.RUNNER1] = gameObject;
                    }
                    else
                    {
                        PlayerManagerScript.Instance.players[PlayerManagerScript.RUNNER2] = gameObject;
                    }
                    break;
                case STATE.TRAPPER:
                    if (PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER1] == null)
                    {
                        PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER1] = gameObject;
                    }
                    else
                    {
                        PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER2] = gameObject;
                    }
                    break;

            }
        }


    }
    public void Back(InputAction.CallbackContext context)
    {
        if (Comfirmation == true)
        {
            Comfirmation = false;
            GameManager.Instance.ActivePlayer--;
            GameManager.Instance.checkUI();
            controllerImage.sprite = Resources.Load<Sprite>("UI_PROJECT/White_Controller");
            opaqueFilter.color = new Color(0f, 0f, 0f, 0f);
            switch (_state)
            {
                case STATE.RUNNER:
                    if (PlayerManagerScript.Instance.players[PlayerManagerScript.RUNNER1] == gameObject)
                    {
                        PlayerManagerScript.Instance.players[PlayerManagerScript.RUNNER1] = null;
                    }
                    else
                    {
                        PlayerManagerScript.Instance.players[PlayerManagerScript.RUNNER2] = null;
                    }
                    break;
                case STATE.TRAPPER:
                    if (PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER1] == gameObject)
                    {
                        PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER1] = null;
                    }
                    else
                    {
                        PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER2] = null;
                    }
                    break;
                case STATE.MIDDLE:
                    return;
            }
        }

    }

    public void InitPlayer()
    {
       
            switch (_state)
            {
                case STATE.RUNNER:
                    transform.SetParent(null);
                    /*transform.localScale = new Vector3(1, 1, 1);
                    transform.position = Vector3.zero;*/
                    runnerRef = Instantiate(GameManager.Instance.Runner.gameObject, GameManager.Instance.spawn.position, Quaternion.identity);
                    GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                    InitRunner();



                    break;

                case STATE.TRAPPER:
                    transform.SetParent(null);
                    /*transform.localScale = new Vector3(1, 1, 1);
                    transform.position = Vector3.zero;*/
                    TrapperRef = Instantiate(GameManager.Instance.Trapper.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
                    GetComponent<PlayerInput>().SwitchCurrentActionMap("Trapper");
                    InitTrapper();
                    break;

                default:
                    Debug.LogError("ERREUR");
                    break;
            }
            DontDestroyOnLoad(gameObject);


    }

    void InitRunner()
    {
        
        
        GetComponent<PlayerInput>().actions.FindAction("Echap").performed += new Action<InputAction.CallbackContext>(GameObject.Find("Pause").GetComponent<Pause>().PausePressed);
        GetComponent<PlayerInput>().actions.FindAction("Movement").performed += new Action<InputAction.CallbackContext>(runnerRef.GetComponent<TESTCONTROLER>().OnMove);
        GetComponent<PlayerInput>().actions.FindAction("Jump").performed += new Action<InputAction.CallbackContext>(runnerRef.GetComponent<TESTCONTROLER>().OnJump);
        GetComponent<PlayerInput>().actions.FindAction("Sliding").performed += new Action<InputAction.CallbackContext>(runnerRef.GetComponent<TESTCONTROLER>().OnSlide);
        //runnerRef.SetActive(false);
    }

    void InitTrapper()
    {
        GetComponent<PlayerInput>().actions.FindAction("Echap").performed += new Action<InputAction.CallbackContext>(GameObject.Find("Pause").GetComponent<Pause>().PausePressed);
        //TrapperRef.SetActive(false);
    }
}