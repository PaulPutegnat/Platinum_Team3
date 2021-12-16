using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutoPortal : MonoBehaviour
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
            tutoCanvas.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("UI_PROJECT/Tuto_UI/XboxOne_X");
            tutoCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "to open the portal";

            tutoCanvas.transform.position = transform.position + new Vector3(12, 20f, -7);
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
