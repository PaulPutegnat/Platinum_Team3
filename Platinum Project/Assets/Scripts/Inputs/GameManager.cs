using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public Controler Runner;
    public TrapController Trapper;
    public GameObject[] players;
    public Transform spawn;

    public float TrapperNumber = 0;
    public float RunnererNumber = 0;
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }

    private void Start()
    {
        /*players[0] = Instantiate(Runner.gameObject, spawn.position, Quaternion.identity);
        players[1] = Instantiate(Runner.gameObject, spawn.position + new Vector3(0,0,5), Quaternion.identity);
        players[2] = Instantiate(Trapper.gameObject, new Vector3(0,0,0), Quaternion.identity);
        players[3] = Instantiate(Trapper.gameObject, new Vector3(0,0,0), Quaternion.identity);*/
    }

    void instantiateRunner()
    {
        if (GetComponent<PlayerInputManager>().playerCount < 4)
            Instantiate(Runner.gameObject, spawn.position, Quaternion.identity);

    }

    void instantiateTrapper()
    {
        if (GetComponent<PlayerInputManager>().playerCount < 4)
            Instantiate(Trapper.gameObject, spawn.position, Quaternion.identity);
    }
}
