using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public GameObject[] playersRefs;

    [Header("Fortune Wheel")]
    public GameObject fortuneWheel;

    [Header("Canvas")]
    public GameObject pauseCanvas;
    public GameObject mainCanvas;

    [HideInInspector]public GameObject BeginButton;
    private GameObject TrapContainer;

    private GameObject pausegGameObject;
    public GameObject TrappersVictoryScreen;

    [Header("Spawn")]
    public Transform spawn;

    public float TrapperNumber = 0;
    public float RunnererNumber = 0;

    [HideInInspector] public bool IsBegin = false;
    [HideInInspector] public bool withWheel = false;
    [HideInInspector] public bool IsFWAlreadyInstantiate = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;

        Time.timeScale = 1f;
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
        TryGetButton();
    }

    public void TryGetButton()
    {
        if(GameObject.Find("BeginButton")!= null)
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
            if(BeginButton != null)
                BeginButton.GetComponent<Button>().interactable = false;

            GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(null);
        }

    }

    public void ButtonPressed()
    {
        Debug.Log("debut");
        PlayerManagerScript.Instance.InitPlayerGame();
        Camera.main.GetComponent<TestCam>().enabled = true;
        IsGamePlaying = true;
        MaterialDispenser.Instance.ApplyMat();
        GameObject.FindGameObjectWithTag("AEnlever").SetActive(false);

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
        if (!IsFWAlreadyInstantiate)
        {
            GameObject newFortuneWheel = Instantiate(fortuneWheel, GameObject.FindGameObjectWithTag("GameContainer").transform);
            IsFWAlreadyInstantiate = true;
        }
        
    }

    public void CheckRunnersDeath()
    {
        DeadPlayer++;
        AudioManager.Instance.PlaySingleSound("Runners_Death_Sound");
        switch (DeadPlayer)
        {
            case 2:
                if (PlayerManagerScript.Instance.RoundNumberDone % 2 != 0)
                {
                    PlayerManagerScript.Instance.Team2Score++;
                }
                else
                {
                    PlayerManagerScript.Instance.Team1Score++;
                }
                TrappersVictoryScreen.SetActive(true);
                AudioManager.Instance.PlaySingleSound("Trappers_Victory_Jingle_Sound");
                GameObject.Find("TrapManager").SetActive(false);
                Camera.main.GetComponent<TestCam>().enabled = false;
                GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(GameObject.Find("NextGameButton").GetComponentInChildren<Button>().gameObject);
                break;
        }
    }

}
