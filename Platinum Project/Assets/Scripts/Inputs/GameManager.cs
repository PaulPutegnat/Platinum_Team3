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

    [Header("Prefab")]
    public TESTCONTROLER Runner;
    public TrapController Trapper;
    public GameObject[] players;
    public GameObject fortuneWheel;

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
    }

    public void Start()
    {
        canvas = FindObjectOfType<Canvas>().transform;
    }

    public void SpawnFortuneWheel()
    {
        GameObject fortuneWheelGameObject = Instantiate(fortuneWheel, Vector3.zero, Quaternion.identity, canvas);
        fortuneWheelGameObject.transform.localPosition = Vector3.zero;
    }


}
