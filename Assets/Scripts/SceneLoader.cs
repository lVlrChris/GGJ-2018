using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string gamesceneName;
    public string menuSceneName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("Loading " + gamesceneName + "...");
        SceneManager.LoadScene(gamesceneName);
    }

    public void MainMenu()
    {
        Debug.Log("Loading " + menuSceneName + "...");
        SceneManager.LoadScene(menuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
