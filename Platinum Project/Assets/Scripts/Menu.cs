using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string sceneToPlay;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToPlay);
    }

    public void ExitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
