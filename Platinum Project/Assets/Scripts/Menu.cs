using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("07_Scene_Pres",LoadSceneMode.Single);
    }

    public void BackToMenu()
    {
        Destroy(PlayerManagerScript.Instance.gameObject);
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
