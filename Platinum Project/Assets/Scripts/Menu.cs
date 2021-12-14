using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }

    public void Retry()
    {
        PlayerManagerScript.Instance.ResetRound();
    }
    public void NextGame()
    {
        PlayerManagerScript.Instance.StartCoroutine(PlayerManagerScript.Instance.NextRound());
    }
}
