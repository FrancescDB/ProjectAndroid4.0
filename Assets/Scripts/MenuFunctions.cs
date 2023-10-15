using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuFunctions : MonoBehaviour
{
    private int state;
    private bool elected;

    public TMP_Text playText;
    public TMP_Text exitText;
    public GameObject playObj;
    public GameObject exitObj;
    public GameObject gear1obj;
    public GameObject gear2obj;
    public GameObject gear3obj;
    public GameObject gear4obj;

    private void Start()
    {
        playText.enabled = true;
        exitText.enabled = true;

        elected = false;
        state = 0;
    }

    public void Play()
    {
        if (elected == false)
        {
            elected = true;
            state = 1;
            playObj.GetComponent<Animator>().Play("Closing");
            gear1obj.GetComponent<Animator>().Play("GoingRight");
            gear2obj.GetComponent<Animator>().Play("GoingLeft");
            StartCoroutine(Selecting());
        }
    }

    public void Exit()
    {
        if (elected == false)
        {
            elected = true;
            state = 2;
            exitObj.GetComponent<Animator>().Play("Closing");
            gear3obj.GetComponent<Animator>().Play("GoingRight");
            gear4obj.GetComponent<Animator>().Play("GoingLeft");
            StartCoroutine(Selecting());
        }
    }

    IEnumerator Selecting()
    {
        yield return new WaitForSeconds(0.2f);

        if (state == 1)
        {
            playText.enabled = false;
        }
        else
        {
            exitText.enabled = false;
        }

        yield return new WaitForSeconds(0.2f);

        if (state == 1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Application.Quit();
        }
    }
}
