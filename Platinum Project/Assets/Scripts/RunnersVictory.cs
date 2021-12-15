using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnersVictory : MonoBehaviour
{
    public GameObject RunnersVictoryScreen;
    public ParticleSystem PS;
   

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
        
        if (PlayerManagerScript.Instance.RoundNumberDone % 2 != 0)
        {
            PlayerManagerScript.Instance.Team1Score++;
        }
        else
        {
            PlayerManagerScript.Instance.Team2Score++;
        }
        PlayerManagerScript.Instance.UpdateScore();
        RunnersVictoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
