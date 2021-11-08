using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
//using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private int MaxPlayers;
    public int ActivePlayer = 0;

    [Header("Prefab")]
    public TESTCONTROLER Runner;
    public TrapController Trapper;
    public GameObject[] players;
    public GameObject fortuneWheel;


    private GameObject RUNNERPANNEL;
    private GameObject TRAPPERPANNEL;


    [Header("Spawn")]
    public Transform spawn;
    private Transform canvas;

    public float TrapperNumber = 0;
    public float RunnererNumber = 0;
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        MaxPlayers = GetComponent<PlayerInputManager>().maxPlayerCount;
    }

    public void Start()
    {
        RUNNERPANNEL = GameObject.Find("RUNNER");
        TRAPPERPANNEL = GameObject.Find("TRAPPER");
        checkUI();
        canvas = GameObject.Find("Canvas").transform;
    }

    private void Update()
    {
        Debug.Log(GetComponent<PlayerInputManager>().playerCount);
    }

    public void SpawnFortuneWheel()
    {
        GameObject fortuneWheelGameObject = Instantiate(fortuneWheel, Vector3.zero, Quaternion.identity, canvas);
        fortuneWheelGameObject.transform.localPosition = Vector3.zero;
    }

    public void checkUI()
    {
        
        if (ActivePlayer == GetComponent<PlayerInputManager>().playerCount)
        {
            RUNNERPANNEL.SetActive(false);
            TRAPPERPANNEL.SetActive(false);
        }
        else
        {
            RUNNERPANNEL.SetActive(true);
            TRAPPERPANNEL.SetActive(true);
        }
    }

}
