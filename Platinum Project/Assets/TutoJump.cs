using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutoJump : MonoBehaviour
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
            tutoCanvas.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("UI_PROJECT/Tuto_UI/XboxOne_A");
            tutoCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "to jump";

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
