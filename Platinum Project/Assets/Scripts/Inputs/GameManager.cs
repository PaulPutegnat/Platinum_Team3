using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [Header("Prefab")]
    public TESTCONTROLER Runner;
    public TrapController Trapper;
    public GameObject[] players;

    [Header("Spawn")]
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


}
