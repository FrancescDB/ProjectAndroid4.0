using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Barrier : MonoBehaviour
{
    private int direction;
    private int life;
    private float speed;
    private Rigidbody rb;
    private GameObject playerObj;

    public GameObject barrierObj;

    private void Start()
    {
        direction = Random.Range(1, 3);

        life = 2;
        speed = 2.5f;

        rb = GetComponent<Rigidbody>();
        playerObj = GameObject.Find("PlayerParent");
    }

    private void Update()
    {
        if (transform.position.y >= 21.47f)
        {
            direction = 1;
        }

        if (transform.position.y <= 2.75)
        {
                direction = 2;
        }

        if (direction == 1)
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }
        
        if (direction == 2)
        {
            rb.velocity = new Vector3(0, speed, 0);
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
        life = life - 1;

        if (life <= 0)
        {
            playerObj.GetComponent<PlayerController>().points = playerObj.GetComponent<PlayerController>().points + 100;
            Destroy(barrierObj);
        }
    }
}
