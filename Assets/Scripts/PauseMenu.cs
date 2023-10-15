using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject MenuObj;
    public GameObject DeathObj;
    public GameObject UI;
    public GameObject BackgroundCanvas;

    private void Start()
    {
        MenuObj.SetActive(false);
        DeathObj.SetActive(false);
        UI.SetActive(true);
        BackgroundCanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        MenuObj.SetActive(true);
        UI.SetActive(false);
        BackgroundCanvas.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        MenuObj.SetActive(false);
        BackgroundCanvas.SetActive(true);
        UI.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        MenuObj.SetActive(false);
        BackgroundCanvas.SetActive(true);
        UI.SetActive(true);
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        MenuObj.SetActive(false);
        BackgroundCanvas.SetActive(true);
        UI.SetActive(true);
        Application.Quit();
    }
}
