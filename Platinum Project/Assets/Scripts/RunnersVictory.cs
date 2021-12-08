using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnersVictory : MonoBehaviour
{
    public GameObject RunnersVictoryScreen;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Player"))
        {
            RunnersVictoryScreen.SetActive(true);
            GameObject.Find("TrapManager").SetActive(false);
            Camera.main.GetComponent<TestCam>().enabled = false;
        }
    }
}
