using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsOffCamera : MonoBehaviour
{
    public GameObject TrappersWin;
    // Start is called before the first frame update
    public void OnBecameVisible()
    {
        Debug.Log("Player is Visible !");
    }

    public void OnBecameInvisible()
    {
        Debug.Log("Player is Invisible !");
        TrappersWin.SetActive(true);
    }
}
