using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float bulletSpeed;
    private bool alreadyShot;
    private Vector2 shotDirection;
    private GameObject playerObj;

    void Start()
    {
        alreadyShot = false;
        bulletSpeed = 10f;

        playerObj = GameObject.Find("PlayerParent");
    }

    void Update()
    {
        if (alreadyShot == false)
        {
            shotDirection = new Vector2(playerObj.transform.position.x - transform.parent.position.x, playerObj.transform.position.y - transform.parent.position.y).normalized;

            alreadyShot = true;
        }
    }

    private void FixedUpdate()
    {
        if (alreadyShot == true)
        {
            transform.Translate(new Vector3(shotDirection.x, shotDirection.y, 0) * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Bullet" && other.gameObject.tag != "Laser" && other.gameObject.tag != "Enemy" && other.gameObject.tag != "Obstacle")
        {
            alreadyShot = false;
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        alreadyShot = false;
        gameObject.SetActive(false);
    }
}
