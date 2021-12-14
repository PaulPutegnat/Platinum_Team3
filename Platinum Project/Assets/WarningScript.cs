using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningScript : MonoBehaviour
{

    [SerializeField]private Animator WarningRight;
    [SerializeField] private Animator WarningLeft;


    public void PlayLeft()
    {
        WarningLeft.Play("WarningLeft_Active");
    }

    public void PlayRight()
    {
        WarningRight.Play("WarningRight_Active");
    }



}
