using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application.Quit()");
    }
}
