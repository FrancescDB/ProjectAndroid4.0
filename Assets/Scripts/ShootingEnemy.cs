using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    private float bulletOffset;
    private float rotationPos;
    private bool attack;
    private Vector2 rotationAngle;
    private GameObject bulletPoolObj;
    private GameObject playerObj;
    private AudioSource shoot2;

    public int life;
    public GameObject bulletPointObj;
    public GameObject jettObj;

    void Start()
    {
        life = 3;
        bulletOffset = 0.1f;

        attack = false;

        bulletPoolObj = GameObject.Find("EnemyBulletPool");
        playerObj = GameObject.Find("PlayerParent");

        shoot2 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, playerObj.transform.position) <= 20)
        {
            rotationAngle = new Vector2(playerObj.transform.position.x - transform.position.x, playerObj.transform.position.y - transform.position.y);

            rotationPos = Mathf.Atan2(rotationAngle.x, rotationAngle.y) * Mathf.Rad2Deg;

            if (attack == false)
            {
                StartCoroutine(StartAttack());
            }

            if (playerObj.transform.position.x <= transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -rotationPos - 90f);
            }
            
            if (playerObj.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, rotationPos - 90f);
            }
        }
        if (Vector3.Distance(transform.position, playerObj.transform.position) > 20)
        {
            StopAllCoroutines();
            attack = false;  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            GetDamage();
        }
    }

    void GetDamage()
    {
        life--;

        if (life <= 0)
        {
            playerObj.GetComponent<PlayerController>().points = playerObj.GetComponent<PlayerController>().points + 200;
            Destroy(jettObj);
        }
    }

    IEnumerator StartAttack()
    {
        attack = true;
        yield return new WaitForSeconds(1f);
        GameObject bullet = EnemyPooling.Instance.RequestBullet();

        if (playerObj.transform.position.x >= transform.position.x)
        {
            bullet.transform.SetParent(bulletPointObj.transform);
            bullet.transform.position = bulletPointObj.transform.position + Vector3.right * bulletOffset;
        }

        if (playerObj.transform.position.x < transform.position.x)
        {
            bullet.transform.SetParent(bulletPointObj.transform);
            bullet.transform.position = bulletPointObj.transform.position + Vector3.left * bulletOffset;
        }

        attack = false;

        yield return null;

        bullet.transform.SetParent(bulletPoolObj.transform);

        shoot2.Play();
    }
}
