using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObjectScript : MonoBehaviour
{
    private int direction;
    private float speed;
    private bool alreadyShooted;
    private Vector2 shootingDirection;
    private Vector2 directionAngle;

    public GameObject playerObj;

    void Start()
    {
        direction = 0;
        speed = 20f;
        alreadyShooted = false;
    }

    private void Update()
    {
        if (alreadyShooted == false)
        {
            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                direction = 1;
            }
            else
            {
                direction = 2;
            }

            shootingDirection = playerObj.GetComponent<PlayerController>().inputShooting;
            alreadyShooted = true;
        }
    }

    private void FixedUpdate()
    {
        directionAngle = new Vector2(shootingDirection.x, shootingDirection.y).normalized;

        if (alreadyShooted == true)
        {
            if (shootingDirection == new Vector2(0, 0))
            {
                switch (direction)
                {
                    case 1:
                        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
                        break;

                    case 2:
                        transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime, Space.World);
                        break;
                }
            }
            else
            {
                transform.Translate(new Vector3(directionAngle.x, directionAngle.y, 0) * speed * Time.deltaTime, Space.World);

                switch (playerObj.GetComponent<PlayerController>().powerupState)
                {
                    case 0:
                        speed = 20f;
                        break;

                    case 1:
                        speed = 22f;
                        break;

                    case 2:
                        speed = 24f;
                        break;

                    case 3:
                        speed = 26f;
                        break;

                    case 4:
                        speed = 28f;
                        break;

                    case 5:
                        speed = 30f;
                        break;

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Laser" && other.gameObject.tag != "Bullet" && other.gameObject.tag != "Player" && other.gameObject.tag != "MainCamera")
        {
            alreadyShooted = false;
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        alreadyShooted = false;
        gameObject.SetActive(false);
    }
}
