using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text distance;
    public TMP_Text powerUpQuantity;
    public Image life1, life2, life3, life4, life5, powerup, recarge;
    public Sprite lifeOn;
    public Sprite lifeOff;
    public Sprite powerupOn;
    public Sprite powerupOff;
    public Sprite load1;
    public Sprite load2;
    public Sprite load3;
    public GameObject playerObj;
    public GameObject cameraObj;

    void Start()
    {
        life1.sprite = lifeOn;
        life2.sprite = lifeOn;
        life3.sprite = lifeOn;

        recarge.sprite = load1;
        recarge.enabled = false;

        powerup.sprite = powerupOff;
    }

    void Update()
    {
        powerUpQuantity.text = "x" + playerObj.GetComponent<PlayerController>().powerupState.ToString();

        distance.text = "Distance: " + string.Format("{0:0}", cameraObj.GetComponent<CameraScript>().meters) + "m";

        score.text = "Score: " + string.Format("{0:0}", cameraObj.GetComponent<CameraScript>().meters + playerObj.GetComponent<PlayerController>().points);

        switch (playerObj.GetComponent<PlayerController>().life)
        {
            case 5:
                life5.sprite = lifeOn;
                life4.sprite = lifeOn;
                life3.sprite = lifeOn;
                life2.sprite = lifeOn;
                life1.sprite = lifeOn;
                break;

            case 4:
                life5.sprite = lifeOff;
                life4.sprite = lifeOn;
                life3.sprite = lifeOn;
                life2.sprite = lifeOn;
                life1.sprite = lifeOn;
                break;

            case 3:
                life5.sprite = lifeOff;
                life4.sprite = lifeOff;
                life3.sprite = lifeOn;
                life2.sprite = lifeOn;
                life1.sprite = lifeOn;
                break;

            case 2:
                life5.sprite = lifeOff;
                life4.sprite = lifeOff;
                life3.sprite = lifeOff;
                life2.sprite = lifeOn;
                life1.sprite = lifeOn;
                break;

            case 1:
                life5.sprite = lifeOff;
                life4.sprite = lifeOff;
                life3.sprite = lifeOff;
                life2.sprite = lifeOff;
                life1.sprite = lifeOn;
                break;

            case 0:
                life5.sprite = lifeOff;
                life4.sprite = lifeOff;
                life3.sprite = lifeOff;
                life2.sprite = lifeOff;
                life1.sprite = lifeOff;
                break;
        }
        
        if (playerObj.GetComponent<PlayerController>().life == 5)
        {
            switch (playerObj.GetComponent<PlayerController>().powerupCount)
            {
                case 0:
                    recarge.enabled = false;
                    break;

                case 1:
                    recarge.sprite = load1;
                    if (playerObj.GetComponent<PlayerController>().powerupState < 5)
                    {
                        recarge.enabled = true;
                    }
                    break;

                case 2:
                    recarge.sprite = load2;
                    if (playerObj.GetComponent<PlayerController>().powerupState < 5)
                    {
                        recarge.enabled = true;
                    }
                    break;

                case 3:
                    recarge.sprite = load3;
                    if (playerObj.GetComponent<PlayerController>().powerupState < 5)
                    {
                        recarge.enabled = true;
                    }
                    break;
            }
        }
        else
        {
            if (playerObj.GetComponent<PlayerController>().powerupCount == 0)
            {
                recarge.enabled = false;
            }
        }

        if (playerObj.GetComponent<PlayerController>().powerupState == 0)
        {
            powerup.sprite = powerupOff;
            powerUpQuantity.enabled = false;
        }
        else
        {
            powerup.sprite = powerupOn;
            powerUpQuantity.enabled = true;
        }
    }
}
