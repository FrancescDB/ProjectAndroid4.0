using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    private int state;
    private float puntuation;
    private bool elected;
    private bool counting;

    public TMP_Text restartText;
    public TMP_Text mainMenuText;
    public TMP_Text exitText;
    public TMP_Text pointText;
    public GameObject gear1;
    public GameObject gear2;
    public GameObject gear3;
    public GameObject gear4;
    public GameObject gear5;
    public GameObject gear6;
    public GameObject restartObj;
    public GameObject mainMenuObj;
    public GameObject exitObj;
    public GameObject playerObj;
    public GameObject cameraObj;

    private void Start()
    {
        restartText.enabled = true;
        mainMenuText.enabled = true;
        exitText.enabled = true;

        elected = false;
        counting = true;
        state = 0;
    }

    private void Update()
    {
        puntuation = playerObj.GetComponent<PlayerController>().points + cameraObj.GetComponent<CameraScript>().meters;

        if (counting == true)
        {
            pointText.text = string.Format("{0:0}", puntuation);
        }
    }

    public void Restart()
    {
        if (elected == false)
        {
            counting = false;
            elected = true;
            state = 1;
            playerObj.GetComponent<PlayerController>().life = 10;
            Time.timeScale = 1f;
            restartObj.GetComponent<Animator>().Play("Closing");
            gear1.GetComponent<Animator>().Play("GoingRight");
            gear2.GetComponent<Animator>().Play("GoingLeft");
            StartCoroutine(Selecting());
        }
    }

    public void MainMenu()
    {
        if (elected == false)
        {
            counting = false;
            elected = true;
            state = 2;
            Time.timeScale = 1f;
            playerObj.GetComponent<PlayerController>().life = 10;
            mainMenuObj.GetComponent<Animator>().Play("Closing");
            gear3.GetComponent<Animator>().Play("GoingRight");
            gear4.GetComponent<Animator>().Play("GoingLeft");
            StartCoroutine(Selecting());
        }
    }

    public void Exit()
    {
        if (elected == false)
        {
            counting = false;
            elected = true;
            state = 3;
            Time.timeScale = 1f;
            playerObj.GetComponent<PlayerController>().life = 10;
            exitObj.GetComponent<Animator>().Play("Closing");
            gear5.GetComponent<Animator>().Play("GoingRight");
            gear6.GetComponent<Animator>().Play("GoingLeft");
            StartCoroutine(Selecting());
        }
    }

    IEnumerator Selecting()
    {
        yield return new WaitForSeconds(0.2f);

        if (state == 1)
        {
            restartText.enabled = false;
        }
        else
        {
            if (state == 2)
            {
                mainMenuText.enabled = false;
            }
            else
            {
                exitText.enabled = false;
            }
        }

        yield return new WaitForSeconds(0.2f);

        if (state == 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            if (state == 2)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
