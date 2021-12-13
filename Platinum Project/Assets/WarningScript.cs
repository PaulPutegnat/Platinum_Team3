using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Right;
    public bool Left;

    private Animator Warning;
    // Update is called once per frame
    private void Start()
    {
        Warning = GetComponent<Animator>();
    }


    public void PlayLeft()
    {
        Warning.Play("Warning_Left");
    }

    public void PlayRight()
    {
        Warning.Play("Warning_Right");
    }



}
