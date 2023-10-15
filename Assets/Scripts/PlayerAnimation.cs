using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private float moveLine;
    private Animator playerAnim;

    public GameObject playerObj;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        moveLine = Mathf.Atan2(playerObj.GetComponent<PlayerController>().inputMovement.x, playerObj.GetComponent<PlayerController>().inputMovement.y) * Mathf.Rad2Deg;

        if (playerObj.GetComponent<PlayerController>().inputMovement == new Vector2(0, 0))
        {
            playerAnim.SetBool("Idle", true);
        }
        else
        {
            playerAnim.SetBool("Idle", false);
        }

        if (moveLine > -22.5f && moveLine <= 22.5f)
        {
            playerAnim.SetFloat("Vector", 0f);
        }

        if (moveLine > 22.5f && moveLine <= 67.5f)
        {
            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                playerAnim.SetFloat("Vector", 0.5f);
            }
            else
            {
                playerAnim.SetFloat("Vector", 2.5f);
            }
        }

        if (moveLine > 67.5f && moveLine <= 112.5f)
        {
            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                playerAnim.SetFloat("Vector", 1f);
            }
            else
            {
                playerAnim.SetFloat("Vector", 3f);
            }
        }

        if (moveLine > 112.5f && moveLine <= 157.5f)
        {
            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                playerAnim.SetFloat("Vector", 1.5f);
            }
            else
            {
                playerAnim.SetFloat("Vector", 3.5f);
            }
        }

        if (moveLine <= -157.5f || moveLine > 157.5f)
        {
            playerAnim.SetFloat("Vector", 2f);
        }

        if (moveLine <= -112.5f && moveLine > -157.5f)
        {
            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                playerAnim.SetFloat("Vector", 2.5f);
            }
            else
            {
                playerAnim.SetFloat("Vector", 0.5f);
            }
        }

        if (moveLine <= -67.5f && moveLine > -112.5f)
        {
            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                playerAnim.SetFloat("Vector", 3f);
            }
            else
            {
                playerAnim.SetFloat("Vector", 1f);
            }
        }

        if (moveLine <= -22.5 && moveLine > -67.5f)
        {
            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                playerAnim.SetFloat("Vector", 3.5f);
            }
            else
            {
                playerAnim.SetFloat("Vector", 1.5f);
            }
        }  
    }
}
