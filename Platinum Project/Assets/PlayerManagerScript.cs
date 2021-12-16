using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManagerScript : MonoBehaviour
{
    public static PlayerManagerScript Instance;
    public GameObject[] players;

    public int Team1Score = 0;
    public int Team2Score = 0;

    public const int RUNNER1 = 0;
    public const int RUNNER2 = 1;
    public const int TRAPPER1 = 2;
    public const int TRAPPER2 = 3;

    public int RoundNumberDone = 1;
    [SerializeField]GameObject SH;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            players = new GameObject[4];
            SH = GameObject.Find("ScoreHolder");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetRound();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(NextRound());
        }
    }

    public void InitPlayerGame()
    {
       
                for(int i = 0; i<4; i++)
                {
                    if (players[i])
                    {
                        players[i].GetComponent<neutralcontroller>().InitPlayer();
                    }

                }

    }

    public void ResetRound()
    {
       
            for (int i = 0; i < 4; i++)
            {
                if (players[i])
                {
                    Destroy(players[i]);
                }

                
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            
            RoundNumberDone = 1;
            Team1Score = 0;
            Team2Score = 0;
      


}

    public IEnumerator NextRound()
    {

            RoundNumberDone++;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = false;
            yield return (asyncLoad.progress > 0.9f);
            StartCoroutine(loaded(asyncLoad));

    }
    IEnumerator loaded(AsyncOperation sync)
    {
        
        sync.allowSceneActivation = true;
        ReversePlayerArray();
        yield return new WaitForSeconds(0.1f);
 
        GameManager.Instance.ButtonPressed();
    }

    void ReversePlayerArray()
    {
        GameObject[] temp = players;
        players = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            if (temp[i] != null)
            {
                switch (i)
                {
                    case 0:
                        players[TRAPPER1] = temp[0];
                        players[TRAPPER1].GetComponent<neutralcontroller>()._state = neutralcontroller.STATE.TRAPPER;
                        break;
                    case 1:
                        players[TRAPPER2] = temp[1];
                        players[TRAPPER2].GetComponent<neutralcontroller>()._state = neutralcontroller.STATE.TRAPPER;
                        break;
                    case 2:
                        players[RUNNER1] = temp[2];
                        players[RUNNER1].GetComponent<neutralcontroller>()._state = neutralcontroller.STATE.RUNNER;
                        break;
                    case 3:
                        players[RUNNER2] = temp[3];
                        players[RUNNER2].GetComponent<neutralcontroller>()._state = neutralcontroller.STATE.RUNNER;
                        break;
                }
            }


        }
    }

    
}
