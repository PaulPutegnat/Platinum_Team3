using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutoSlide : MonoBehaviour
{
    private GameObject tutoCanvas;

    private void Start()
    {
        tutoCanvas = GameObject.FindGameObjectWithTag("TutoCanvas");
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            tutoCanvas.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Tuto_UI/XboxOne_B");
            tutoCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "to slide";

            tutoCanvas.transform.position = transform.position;
            tutoCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            tutoCanvas.SetActive(false);
        }
    }
}
