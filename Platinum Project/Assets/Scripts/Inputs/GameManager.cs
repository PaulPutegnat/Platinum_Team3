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
    public int DeadPlayer = 0;

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

    private GameObject BeginButton;
    private GameObject TrapContainer;

    private GameObject pausegGameObject;
    public GameObject TrappersVictoryScreen;

    [Header("Spawn")]
    public Transform spawn;

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
        TrapContainer = GameObject.FindGameObjectWithTag("TrapContainer");
        TrapContainer.SetActive(false);
    }

    public void Start()
    {
        Camera.main.GetComponent<TestCam>().enabled = false;
        BeginButton = GameObject.Find("BeginButton");
    }

    public void checkUI()
    {
        
        if (ActivePlayer == GetComponent<PlayerInputManager>().playerCount && ActivePlayer > 0) //Changer � ActivePlayer == GetComponent<PlayerInputManager>().maxPlayerCount pour le JEU FINAL
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

            GameObject objetAEnlever = GameObject.FindGameObjectWithTag("AEnlever");
            objetAEnlever.SetActive(false);

            for (int index = 0; index < MaxPlayers; index++)
            {
                if (playersRefs[index])
                {
                    playersRefs[index].SetActive(true);
                }
            }
            GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(GameObject.FindObjectOfType<Pause>().FirstSelectedInUI);
            TrapContainer.SetActive(true);
            
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
        GameObject newFortuneWheel = Instantiate(fortuneWheel, GameObject.FindGameObjectWithTag("TrapManager").transform);
    }

    public void CheckRunnersDeath()
    {
        DeadPlayer++;
        DeadPlayer++;
        switch (DeadPlayer)
        {
            case 2:
                TrappersVictoryScreen.SetActive(true);
                GameObject.Find("TrapManager").SetActive(false);
                Camera.main.GetComponent<TestCam>().enabled = false;
                break;
        }
    }

}
