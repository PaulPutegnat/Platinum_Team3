using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnersVictory : MonoBehaviour
{
    public GameObject RunnersVictoryScreen;

    public GameObject P_Force;
    public ParticleSystem PS;
    private void Start()
    {
        P_Force.SetActive(true);
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.name.Contains("Player"))
        {
            StartCoroutine(Victory());
            var emission = PS.emission;
            emission.rateOverTime = 60f;
            var Force = PS.forceOverLifetime;
            Force.enabled = true;
            emission.enabled = false;
            GameObject.Find("TrapManager").SetActive(false);
            Camera.main.GetComponent<TestCam>().enabled = false;
        }
    }

    IEnumerator Victory()
    {

        yield return new WaitForSeconds(1);
        var emission = PS.emission;
        emission.enabled = false;
        RunnersVictoryScreen.SetActive(true);
    }
}
