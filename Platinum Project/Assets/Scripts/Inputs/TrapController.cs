using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrapController : MonoBehaviour
{
    [SerializeField] private GameObject[] Traps = new GameObject[2];
  

    public void initTrapper(int index)
    {
        if (index == 2)
        {
            Traps[0] = GameObject.Find("Trap1");
            Traps[1] = GameObject.Find("Trap2");
        }
        else if (index == 3)
        {
            Traps[0] = GameObject.Find("Trap3");
            Traps[1] = GameObject.Find("Trap4");
        }
    }

    public void SlidingGameInput(InputAction.CallbackContext context)
    {
        if (GameObject.FindObjectOfType<SlidingBarGame>())
        {
            //Call de la fonction
            //GameObject.FindObjectOfType<SlidingBarGame>()."future fonction"
        }
    }
}
