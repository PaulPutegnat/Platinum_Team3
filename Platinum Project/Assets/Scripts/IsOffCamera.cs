using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsOffCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnBecameVisible()
    {
        Console.Clear();
        Debug.Log("Player is Visible !");
    }

    public void OnBecameInvisible()
    {
        Console.Clear();
        Debug.Log("Player is Invisible !");
        SceneManager.LoadScene("Victoire");
    }
}
