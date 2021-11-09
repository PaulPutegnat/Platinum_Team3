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

    [Header("Prefab")]
    public TESTCONTROLER Runner;
    public TrapController Trapper;
    public GameObject[] players;
    public GameObject fortuneWheel;


    private GameObject RUNNERPANNEL;
    private GameObject TRAPPERPANNEL;
    private GameObject BeginButton;


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
            StartCoroutine(WaitForBegin());

        }

    }

    public void ButtonPressed()
    {

            RUNNERPANNEL.SetActive(false);
            TRAPPERPANNEL.SetActive(false);
            BeginButton.SetActive(false);

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
