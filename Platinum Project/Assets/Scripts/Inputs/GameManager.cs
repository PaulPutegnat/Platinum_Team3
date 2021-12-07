using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEditor.Animations;
//using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int MaxPlayers;
    public int ActivePlayer = 0;

    public bool IsGamePlaying = false;

    [Header("Prefab")]
    public TESTCONTROLER Runner;
    public TrapController Trapper;
    [HideInInspector]
    public GameObject[] players;

    [HideInInspector]
    public GameObject[] playersRefs;

    [Header("Fortune Wheel")]
    public GameObject fortuneWheel;

    [Header("Canvas")]
    public GameObject pauseCanvas;
    public GameObject mainCanvas;

    private GameObject RUNNERPANNEL;
    private GameObject TRAPPERPANNEL;
    private GameObject BeginButton;

    private GameObject pausegGameObject;


    [Header("Spawn")]
    public Transform spawn;
    private Transform canvas;

    public float TrapperNumber = 0;
    public float RunnererNumber = 0;

    public bool IsBegin = false;
    public bool withWheel = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;

        pauseCanvas.SetActive(true);
        mainCanvas.SetActive(true);

        MaxPlayers = GetComponent<PlayerInputManager>().maxPlayerCount;
        playersRefs = new GameObject[MaxPlayers];
        pausegGameObject = pauseCanvas;
    }

    public void Start()
    {
        Camera.main.GetComponent<TestCam>().enabled = false;
        RUNNERPANNEL = GameObject.Find("RUNNER");
        TRAPPERPANNEL = GameObject.Find("TRAPPER");
        BeginButton = GameObject.Find("BeginButton");
    }

    public void checkUI()
    {
        
        if (ActivePlayer == GetComponent<PlayerInputManager>().playerCount && ActivePlayer > 0) //Changer à ActivePlayer == GetComponent<PlayerInputManager>().maxPlayerCount pour le JEU FINAL
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
            Camera.main.GetComponent<TestCam>().enabled = true;
            IsGamePlaying = true;

            GameObject[] objetAEnlever = GameObject.FindGameObjectsWithTag("AEnlever");
            for (int i = 0; i < objetAEnlever.Length; i++)
            {
                objetAEnlever[i].SetActive(false);
            }

            for (int index = 0; index < MaxPlayers; index++)
            {
                if (playersRefs[index])
                {
                    playersRefs[index].SetActive(true);
                }
            }
            GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(GameObject.FindObjectOfType<Pause>().FirstSelectedInUI);

            if (withWheel)
            {
                SpawnFortuneWheel();
            }
            
            IsBegin = true;
    }

    IEnumerator WaitForBegin()
    {
        yield return new WaitForSeconds(0.1f);
        BeginButton.GetComponent<Button>().interactable = true;
    }

    public void SpawnFortuneWheel()
    {
        GameObject newFortuneWheel = Instantiate(fortuneWheel, GameObject.FindGameObjectWithTag("Canvas").transform);
    }

    

}
