using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("03_Scene_Pres");
    }

    public void ExitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
