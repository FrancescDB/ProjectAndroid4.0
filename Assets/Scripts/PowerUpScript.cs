using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    private GameObject playerObj;

    private void Start()
    {
        playerObj = GameObject.Find("PlayerParent");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerObj.GetComponent<PlayerController>().life < 5)
            {
                playerObj.GetComponent<PlayerController>().life = playerObj.GetComponent<PlayerController>().life + 1;
                Destroy(this.gameObject);
            }
            else
            {
                if (playerObj.GetComponent<PlayerController>().powerupCount < 3)
                {
                    playerObj.GetComponent<PlayerController>().powerupCount = playerObj.GetComponent<PlayerController>().powerupCount + 1;
                    Destroy(this.gameObject);
                }
                else
                {
                    playerObj.GetComponent<PlayerController>().powerupCount = 0;

                    if (playerObj.GetComponent<PlayerController>().powerupState < 5)
                    {
                        playerObj.GetComponent<PlayerController>().powerupState = playerObj.GetComponent<PlayerController>().powerupState + 1;
                    }
                    Destroy(this.gameObject);
                }
            }
        }

        playerObj.GetComponent<PlayerController>().points = playerObj.GetComponent<PlayerController>().points + 50;
    }
}
