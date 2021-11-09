using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
//using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    private int MaxPlayers;
    public int ActivePlayer = 0;

    public bool IsGamePlaying = false;

    [Header("Prefab")]
    public TESTCONTROLER Runner;
    public TrapController Trapper;
    public GameObject[] players;
    public GameObject fortuneWheel;


    private GameObject RUNNERPANNEL;
    private GameObject TRAPPERPANNEL;
    private GameObject BeginButton;

    private GameObject pausegGameObject;


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
        pausegGameObject = GameObject.Find("Pause");
    }

    public void Start()
    {
        RUNNERPANNEL = GameObject.Find("RUNNER");
        TRAPPERPANNEL = GameObject.Find("TRAPPER");
        BeginButton = GameObject.Find("BeginButton");
        
        canvas = GameObject.Find("Canvas").transform;
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
            GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(BeginButton);
            StartCoroutine(WaitForBegin());
        }
        else
        {
            BeginButton.GetComponent<Button>().interactable = false;
            GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(null);
        }

    }

    public void ButtonPressed()
    {

            IsGamePlaying = true;


            GameObject[] objetAEnlever = GameObject.FindGameObjectsWithTag("AEnlever");
            for (int i = 0; i < objetAEnlever.Length; i++)
            {
                objetAEnlever[i].SetActive(false);
            }

            for (int index = 0; index < MaxPlayers; index++)
            {
                if (players[index])
                {
                    players[index].SetActive(true);
                }
            }
            GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(GameObject.FindObjectOfType<Pause>().FirstSelectedInUI);
            
            //SpawnFortuneWheel();
    }

    IEnumerator WaitForBegin()
    {
        yield return new WaitForSeconds(0.1f);
        BeginButton.GetComponent<Button>().interactable = true;
    }

}
